namespace Appointments.Application.Actions.Appointments.Commands.CreateUpdate;

public class AppointmentCreateCommand : IRequest<AppointmentResponse<AppointmentModel>>
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    public int Id { get; set; }

    /// <summary>Gets or sets the customer name.</summary>
    /// <value>The customer name</value>
    public string PatientName { get; set; }

    /// <summary>Gets or sets the customer phone.</summary>
    /// <value>The customer phone.</value>
    public string Phone { get; set; }


    /// <summary>Gets or sets the customer phone.</summary>
    /// <value>The customer phone.</value>
    public DateTime AppointmentDateTime { get; set; }


    /// <summary>Gets or sets the customer phone.</summary>
    /// <value>The customer phone.</value>
    public int DoctorId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is marked as deleted.
    /// </summary>
    public bool IsDeleted { get; set; }
}
