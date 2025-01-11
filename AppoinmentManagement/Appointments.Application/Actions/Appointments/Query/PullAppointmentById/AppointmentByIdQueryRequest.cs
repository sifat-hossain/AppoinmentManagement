namespace Appointments.Application.Actions.Appointments.Query.PullAppointmentById;

public class AppointmentByIdQueryRequest : IRequest<AppointmentModel>
{
    /// <summary>Gets or sets the category identifier.</summary>
    /// <value>The category identifier.</value>
    public int Id { get; set; }
}
