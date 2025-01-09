using Base.Domain.Entities;

namespace Appoinments.Domain.Entities;

public class Doctor : BaseEntity
{
    /// <summary>Gets or sets the brand name.</summary>
    /// <value>The brand name.</value>
    public string DoctorName { get; set; }

    /// <summary>Gets or sets the products.</summary>
    /// <value>The products.</value>
    public List<Appointment> Appointments { get; set; }
}
