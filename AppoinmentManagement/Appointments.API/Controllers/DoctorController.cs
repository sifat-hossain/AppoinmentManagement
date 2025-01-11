using Appointments.Application.Actions;
using Appointments.Application.Actions.Doctors;
using Appointments.Application.Actions.Doctors.Commands;
using Appointments.Application.Actions.Doctors.Query.PullDoctors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Appointments.API.Controllers
{
    [Authorize]
    [ApiKeyFilter]
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class DoctorController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("push")]
        public Task<AppointmentResponse<DoctorModel>> Push(DoctorCreateCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpPost("pull")]
        public Task<List<DoctorModel>> Pull(DoctorQueryRequest request)
        {
            return _mediator.Send(request);
        }
    }
}
