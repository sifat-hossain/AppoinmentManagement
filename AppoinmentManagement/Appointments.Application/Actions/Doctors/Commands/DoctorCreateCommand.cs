namespace Appointments.Application.Actions.Doctors.Commands;

public class DoctorCreateCommand : IRequest<AppointmentResponse<DoctorModel>>
{
    /// <summary>
    /// Gets or sets the unique identifier for the Doctor.
    /// </summary>
    public int Id { get; set; }

    /// <summary>Gets or sets the Doctor name.</summary>
    /// <value>The Doctor name.</value>
    public string DoctorName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is marked as deleted.
    /// </summary>
    public bool IsDeleted { get; set; }
}
