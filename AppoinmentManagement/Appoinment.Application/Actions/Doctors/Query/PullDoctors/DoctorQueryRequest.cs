namespace Appoinments.Application.Actions.Doctors.Query.PullDoctors;

public class DoctorQueryRequest : IRequest<List<DoctorModel>>
{
    public int? Skip { get; set; }
    public int? Take { get; set; }
}
