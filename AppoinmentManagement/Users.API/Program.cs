using Appointments.Framework.Interfaces;
using Appointments.Framework.Services;
using Appointments.Framework.Settings;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Users.Application;
using Users.Application.Actions.Users.Commands.CreateUser;
using Users.Infrastractures;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("UserDbConnection"));
    if (builder.Environment.IsDevelopment())
    {
        o.EnableDetailedErrors();
        o.EnableSensitiveDataLogging();
    }
});
builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection("AuthSettings"));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateUserHandler).GetTypeInfo().Assembly));

builder.Services.AddScoped<IUserDbContext, UserDbContext>();
builder.Services.AddScoped<ITokenService, TokenService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
