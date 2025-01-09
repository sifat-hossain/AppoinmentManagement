namespace Appoinments.Application.Actions.Doctors.Commands;

public class DoctorCreateCommand : IRequest<AppoinmentResponse<DoctorModel>>
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    public int Id { get; set; }

    /// <summary>Gets or sets the brand name.</summary>
    /// <value>The brand name.</value>
    public string DoctorName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is marked as deleted.
    /// </summary>
    public bool IsDeleted { get; set; }
}
