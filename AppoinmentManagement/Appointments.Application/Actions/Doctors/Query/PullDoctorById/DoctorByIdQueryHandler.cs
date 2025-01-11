using Appointments.Application.Actions.Doctors;

namespace Appointments.Application.Actions.Doctors.Query.PullDoctorById;

public class DoctorByIdQueryHandler(IAppointmentDbContext appointmentDbContext) :
    IRequestHandler<DoctorByIdQueryRequest, DoctorModel>
{
    private readonly IAppointmentDbContext _appointmentDbContext = appointmentDbContext;

    public async Task<DoctorModel> Handle(DoctorByIdQueryRequest request, CancellationToken cancellationToken)
    {
        Doctor? brand = await _appointmentDbContext.Doctor
            .Where(x => !x.IsDeleted && x.Id == request.Id)
            .OrderByDescending(x => x.CreatedOn)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return brand == null ? throw new Exception("Doctor is not found") : DoctorModel.Create(brand);
    }
}
