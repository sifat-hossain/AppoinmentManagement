namespace Appointments.Application.Actions.Appointments;

public class AppointmentModel : BaseModel
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

    /// <summary>Gets or sets the Doctor id.</summary>
    /// <value>The Doctor id.</value>
    public int DoctorId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is marked as deleted.
    /// </summary>
    public bool IsDeleted { get; set; }

    public static Expression<Func<Appointment, AppointmentModel>> Projection
    {
        get
        {
            return appointment => new AppointmentModel
            {
                Id = appointment.Id,
                PatientName = appointment.PatientName,
                Phone = appointment.Phone,
                DoctorId = appointment.DoctorId,
                AppointmentDateTime = appointment.AppointmentDateTime,
                CreatedOn = appointment.CreatedOn,
                IsDeleted = appointment.IsDeleted
            };
        }
    }

    public static AppointmentModel Create(Appointment entity)
    {
        return Projection.Compile().Invoke(entity);
    }
}
