using Base.Domain.Entities;

namespace Appointments.Domain.Entities;

public class Doctor : BaseEntity
{
    /// <summary>Gets or sets the doctor name.</summary>
    /// <value>The doctor name.</value>
    public string DoctorName { get; set; }

    /// <summary>Gets or sets the appoinments.</summary>
    /// <value>The appoinments.</value>
    public List<Appointment> Appointments { get; set; }
}
