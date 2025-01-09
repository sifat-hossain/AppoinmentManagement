
namespace Appoinments.Application.Actions.Appoinments.Commands;

public class AppoinmentCreateHandler(IAppoinmentDbContext appointmentDbContext) :
    IRequestHandler<AppoinmentCreateCommand, AppoinmentResponse<AppoinmentModel>>
{
    private readonly IAppoinmentDbContext _appointmentDbContext = appointmentDbContext;

    public async Task<AppoinmentResponse<AppoinmentModel>> Handle(AppoinmentCreateCommand command, CancellationToken cancellationToken)
    {

        try
        {
            Appointment? appointment = await _appointmentDbContext.Appointment
                .Where(x => x.PatientName == command.PatientName.Trim()
                && x.AppointmentDateTime == command.AppointmentDateTime)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (appointment == null)
            {
                appointment = new Appointment
                {
                    CreatedOn = DateTime.UtcNow
                };
                _appointmentDbContext.Appointment.Add(appointment);
            }
            appointment.PatientName = command.PatientName;
            appointment.AppointmentDateTime = command.AppointmentDateTime;
            appointment.DoctorId = command.DoctorId;
            appointment.Phone = command.Phone;
            appointment.IsDeleted = command.IsDeleted;

            await _appointmentDbContext.SaveChangesAsync(cancellationToken);
            return new AppoinmentResponse<AppoinmentModel>()
            {
                IsSuccessful = true,
                Message = null,
                Model = AppoinmentModel.Create(appointment)
            };
        }
        catch (Exception ex)
        {
            return new AppoinmentResponse<AppoinmentModel>
            {
                IsSuccessful = false,
                Message = $"Failed to insert category with message: {ex.Message}, inner exception: {ex.InnerException?.Message}",
            };
        }
    }
}
