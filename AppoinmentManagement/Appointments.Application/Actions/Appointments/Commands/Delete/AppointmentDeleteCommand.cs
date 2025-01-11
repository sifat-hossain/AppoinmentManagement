namespace Appointments.Application.Actions.Appointments.Commands.Delete;

public class AppointmentDeleteCommand : IRequest<AppointmentResponse>
{
    /// <summary>Gets or sets the category identifier.</summary>
    /// <value>The category identifier.</value>
    public int Id { get; set; }
}
