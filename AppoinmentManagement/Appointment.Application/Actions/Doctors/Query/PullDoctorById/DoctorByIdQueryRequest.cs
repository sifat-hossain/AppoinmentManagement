using Appointments.Application.Actions.Doctors;

namespace Appointments.Application.Actions.Doctors.Query.PullDoctorById;

public class DoctorByIdQueryRequest : IRequest<DoctorModel>
{
    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The Doctor identifier.</value>
    public int Id { get; set; }
}
