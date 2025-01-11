using Base.Domain.Entities;

namespace Appointments.Domain.Entities;

public class Appointment : BaseEntity
{
    /// <summary>Gets or sets the Patient name.</summary>
    /// <value>The Patient name</value>
    public string PatientName { get; set; }

    /// <summary>Gets or sets the Patient phone.</summary>
    /// <value>The Patient phone.</value>
    public string Phone { get; set; }


    /// <summary>Gets or sets the Appointment Date Time.</summary>
    /// <value>The Appointment Date Time.</value>
    public DateTime AppointmentDateTime { get; set; }


    /// <summary>Gets or sets the doctor id.</summary>
    /// <value>The doctor id.</value>
    public int DoctorId { get; set; }

    /// <summary>Gets or sets the doctor.</summary>
    /// <value>The doctor.</value>
    public Doctor Doctor { get; set; }
}
