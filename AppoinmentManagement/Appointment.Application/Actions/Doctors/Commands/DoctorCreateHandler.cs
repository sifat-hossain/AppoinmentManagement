namespace Appointments.Application.Actions.Doctors.Commands;

public class DoctorCreateHandler(IAppointmentDbContext appointmentDbContext) :
    IRequestHandler<DoctorCreateCommand, AppointmentResponse<DoctorModel>>
{
    private readonly IAppointmentDbContext _appointmentDbContext = appointmentDbContext;

    public async Task<AppointmentResponse<DoctorModel>> Handle(DoctorCreateCommand command, CancellationToken cancellationToken)
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
            return new AppointmentResponse<DoctorModel>()
            {
                IsSuccessful = true,
                Message = null,
                Model = DoctorModel.Create(doctor)
            };
        }
        catch (Exception ex)
        {
            return new AppointmentResponse<DoctorModel>
            {
                IsSuccessful = false,
                Message = $"Failed to insert doctor with message: {ex.Message}," +
                $" inner exception: {ex.InnerException?.Message}",
            };
        }
    }
}
