namespace Appointments.Application.Actions.Appointments.Commands.Delete;

public class AppointmentDeleteCommand : IRequest<AppointmentResponse>
{
    /// <summary>Gets or sets the Appointment identifier.</summary>
    /// <value>The Appointment identifier.</value>
    public int Id { get; set; }
}
