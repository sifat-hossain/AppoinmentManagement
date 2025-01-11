namespace Appointments.Application.Actions.Appointments.Query.PullAppointmentList;

public class AppointmentQueryRequest : IRequest<List<AppointmentModel>>
{
    public int? Skip { get; set; }
    public int? Take { get; set; }
}
