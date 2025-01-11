using Appointments.Domain.Entities;

namespace Appointments.Application.Actions.Doctors;

public class DoctorModel : BaseModel
{
    /// <summary>Gets or sets the Doctor name.</summary>
    /// <value>The Doctor name.</value>
    public string DoctorName { get; set; }

    public static Expression<Func<Doctor, DoctorModel>> Projection
    {
        get
        {
            return entity => new DoctorModel
            {
                Id = entity.Id,
                DoctorName = entity.DoctorName,
                CreatedOn = entity.CreatedOn,
                IsDeleted = entity.IsDeleted
            };
        }
    }

    public static DoctorModel Create(Doctor entity)
    {
        return Projection.Compile().Invoke(entity);
    }
}
