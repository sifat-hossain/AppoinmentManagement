using Appointments.Domain.Entities;

namespace Appointments.Application.Actions.Appointments;

public class AppointmentModel : BaseModel
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
