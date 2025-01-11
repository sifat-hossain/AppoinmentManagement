namespace Appointments.Application.Actions.Appointments.Query.PullAppointmentById;

public class AppointmentByIdQueryRequest : IRequest<AppointmentModel>
{
    /// <summary>Gets or sets the Appointment identifier.</summary>
    /// <value>The Appointment identifier.</value>
    public int Id { get; set; }
}
