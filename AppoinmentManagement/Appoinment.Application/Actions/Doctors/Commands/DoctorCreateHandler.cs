namespace Appoinments.Application.Actions.Doctors.Commands;

public class DoctorCreateHandler(IAppoinmentDbContext appointmentDbContext) :
    IRequestHandler<DoctorCreateCommand, AppoinmentResponse<DoctorModel>>
{
    private readonly IAppoinmentDbContext _appointmentDbContext = appointmentDbContext;

    public async Task<AppoinmentResponse<DoctorModel>> Handle(DoctorCreateCommand command, CancellationToken cancellationToken)
    {
        try
        {
            Doctor? doctor = await _appointmentDbContext.Doctor
                .Where(x => x.Id == command.Id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (doctor == null)
            {
                doctor = new Doctor
                {
                    CreatedOn = DateTime.UtcNow
                };
                _appointmentDbContext.Doctor.Add(doctor);
            }
            doctor.DoctorName = command.DoctorName;
            doctor.IsDeleted = command.IsDeleted;

            await _appointmentDbContext.SaveChangesAsync(cancellationToken);
            return new AppoinmentResponse<DoctorModel>()
            {
                IsSuccessful = true,
                Message = null,
                Model = DoctorModel.Create(doctor)
            };
        }
        catch (Exception ex)
        {
            return new AppoinmentResponse<DoctorModel>
            {
                IsSuccessful = false,
                Message = $"Failed to insert doctor with message: {ex.Message}," +
                $" inner exception: {ex.InnerException?.Message}",
            };
        }
    }
}
