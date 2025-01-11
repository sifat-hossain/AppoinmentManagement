using Appointments.Application.Actions;
using Appointments.Application.Actions.Appointments;
using Appointments.Application.Actions.Appointments.Commands.CreateUpdate;
using Appointments.Application.Actions.Appointments.Commands.Delete;
using Appointments.Application.Actions.Appointments.Query.PullAppointmentById;
using Appointments.Application.Actions.Appointments.Query.PullAppointmentList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Appointments.API.Controllers;

[Authorize]
[ApiKeyFilter]
[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AppointmentController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;


    [HttpPost("push")]
    public Task<AppointmentResponse<AppointmentModel>> CreateAppointment(AppointmentCreateCommand command)
    {
        var validator = new AppointmentCreateValidation();
        var result = validator.Validate(command);
        if (result.IsValid)
        {
            return _mediator.Send(command);
        }
        else
        {
            return Task.FromResult(new AppointmentResponse<AppointmentModel>()
            {
                IsSuccessful = false,
                Message = $"{result.Errors[0].ErrorMessage}"
            });
        }
    }

    [HttpPost("pull")]
    public Task<List<AppointmentModel>> GetAppointments(AppointmentQueryRequest request)
    {
        return _mediator.Send(request);
    }

    [HttpGet("{id}")]
    public Task<AppointmentModel> PullAppointmentByIds(int id)
    {
        AppointmentByIdQueryRequest request = new()
        {
            Id = id
        };
        return _mediator.Send(request);
    }

    [HttpDelete]
    public Task<AppointmentResponse> Delete(int id)
    {
        AppointmentDeleteCommand command = new()
        {
            Id = id
        };
        return _mediator.Send(command);
    }
}
