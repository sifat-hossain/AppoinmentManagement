namespace Appointments.Application.Actions.Appointments.Commands.CreateUpdate;

public class AppointmentCreateCommand : IRequest<AppointmentResponse<AppointmentModel>>
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    public int Id { get; set; }

    /// <summary>Gets or sets the patient name.</summary>
    /// <value>The patient name</value>
    public string PatientName { get; set; }

    /// <summary>Gets or sets the patient phone.</summary>
    /// <value>The patient phone.</value>
    public string Phone { get; set; }


    /// <summary>Gets or sets the Appointment Date Time.</summary>
    /// <value>The Appointment Date Time.</value>
    public DateTime AppointmentDateTime { get; set; }

    /// <summary>Gets or sets the Doctor id.</summary>
    /// <value>The Doctor id.</value>
    public int DoctorId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is marked as deleted.
    /// </summary>
    public bool IsDeleted { get; set; }
}
