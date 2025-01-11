namespace Appointments.Application.Actions.Doctors.Query.PullDoctors;

public class DoctorQueryHandler(IAppointmentDbContext appointmentDbContext) :
    IRequestHandler<DoctorQueryRequest, List<DoctorModel>>
{
    private readonly IAppointmentDbContext _appointmentDbContext = appointmentDbContext;

    public async Task<List<DoctorModel>> Handle(DoctorQueryRequest request, CancellationToken cancellationToken)
    {
        int skip = request.Skip ?? 0;
        int take = request.Take ?? 20;

        List<Doctor> brands = await _appointmentDbContext.Doctor
            .Skip(skip)
            .Take(take)
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x => x.CreatedOn)
            .ToListAsync(cancellationToken: cancellationToken);

        return brands.Count <= 0 ? [] : brands.Select(p => DoctorModel.Create(p)).ToList();
    }
}
