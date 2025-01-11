using Appointments.Application.Actions;
using Appointments.Application.Actions.Appointments;
using Appointments.Application.Actions.Appointments.Commands;
using Appointments.Application.Actions.Appointments.Query.PullAppointmentList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Appointments.API.Controllers;

//[Authorize]
//[ApiKeyFilter]
[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AppointmentController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;


    [HttpPost("push")]
    public Task<AppointmentResponse<AppointmentModel>> PushBrand(AppointmentCreateCommand command)
    {
        return _mediator.Send(command);
    }

    [HttpPost("pull")]
    public Task<List<AppointmentModel>> PullBrands(AppointmentQueryRequest request)
    {
        return _mediator.Send(request);
    }
}
