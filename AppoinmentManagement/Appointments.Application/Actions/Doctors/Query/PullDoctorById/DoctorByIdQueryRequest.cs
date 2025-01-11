namespace Appointments.Application.Actions.Doctors.Query.PullDoctorById;

public class DoctorByIdQueryRequest : IRequest<DoctorModel>
{
    /// <summary>Gets or sets the identifier of Doctor.</summary>
    /// <value>The Doctor identifier.</value>
    public int Id { get; set; }
}
