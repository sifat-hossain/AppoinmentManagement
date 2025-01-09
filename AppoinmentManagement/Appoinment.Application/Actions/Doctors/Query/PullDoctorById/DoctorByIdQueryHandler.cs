namespace Appoinments.Application.Actions.Doctors.Query.PullDoctorById;

public class DoctorByIdQueryHandler(IAppoinmentDbContext appointmentDbContext) :
    IRequestHandler<DoctorByIdQueryRequest, DoctorModel>
{
    private readonly IAppoinmentDbContext _appointmentDbContext = appointmentDbContext;

    public async Task<DoctorModel> Handle(DoctorByIdQueryRequest request, CancellationToken cancellationToken)
    {
        Doctor? brand = await _appointmentDbContext.Doctor
            .Where(x => !x.IsDeleted && x.Id == request.Id)
            .OrderByDescending(x => x.CreatedOn)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return brand == null ? throw new Exception("Doctor is not found") : DoctorModel.Create(brand);
    }
}
