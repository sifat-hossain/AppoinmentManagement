using Base.Domain.Entities;

namespace Appoinments.Domain.Entities;

public class Appointment : BaseEntity
{
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

    /// <summary>Gets or sets the sale.</summary>
    /// <value>The sale.</value>
    public Doctor Doctor { get; set; }
}
