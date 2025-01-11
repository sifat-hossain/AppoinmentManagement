using Appointments.Application;
using Appointments.Application.Actions.Appointments.Commands;
using Appointments.Framework.Settings;
using Appointments.Infrastractures;
using Identity.Http.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(jwtBearerOptions =>
    {
        jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateActor = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["AuthSettings:Issuer"],
            ValidAudience = builder.Configuration["AuthSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["AuthSettings:SigningKey"]))
        };
    });

//builder.Services.AddControllers(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Appointment Management API",
        Description = "Appointment Management API",
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                                    Enter 'Bearer' [space] and then your token in the text input below.
                                    Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        },
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }

            },
            new List<string>()
        }
    });
});

builder.Services.AddDbContext<AppointmentDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("AppointmentDbContext"));
    if (builder.Environment.IsDevelopment())
    {
        o.EnableDetailedErrors();
        o.EnableSensitiveDataLogging();
    }
});

builder.Services.AddScoped<IAppointmentDbContext, AppointmentDbContext>();
builder.Services.AddIdentityContext(options =>
{
    string key = builder.Configuration["AuthSettings:SigningKey"];
    options.SecurityKey = key;
});

builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection("AuthSettings"));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AppointmentCreateHandler).GetTypeInfo().Assembly));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DoctorQueryHandler).GetTypeInfo().Assembly));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
//app.UseAuthentication();
//app.UseAuthorization();
//app.MapControllers();
app.Run();

