namespace Appointments.Application.Actions.Appointments.Commands.CreateUpdate;

public class AppointmentCreateHandler(IAppointmentDbContext appointmentDbContext) :
    IRequestHandler<AppointmentCreateCommand, AppointmentResponse<AppointmentModel>>
{
    private readonly IAppointmentDbContext _appointmentDbContext = appointmentDbContext;

    public async Task<AppointmentResponse<AppointmentModel>> Handle(AppointmentCreateCommand command, CancellationToken cancellationToken)
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
                    CreatedOn = DateTime.Now,
                    PatientName = command.PatientName,
                    AppointmentDateTime = command.AppointmentDateTime,
                    DoctorId = command.DoctorId,
                    Phone = command.Phone,
                    IsDeleted = command.IsDeleted
                };

                _appointmentDbContext.Appointment.Add(appointment);
            }
            else
            {
                appointment.Id = command.Id;
                appointment.ModifiedOn = DateTime.Now;
                appointment.PatientName = command.PatientName;
                appointment.AppointmentDateTime = command.AppointmentDateTime;
                appointment.DoctorId = command.DoctorId;
                appointment.Phone = command.Phone;
                appointment.IsDeleted = command.IsDeleted;

                _appointmentDbContext.Appointment.Update(appointment);
            }
            await _appointmentDbContext.SaveChangesAsync(cancellationToken);

            return new AppointmentResponse<AppointmentModel>()
            {
                IsSuccessful = true,
                Message = null,
                Model = AppointmentModel.Create(appointment)
            };
        }
        catch (Exception ex)
        {
            return new AppointmentResponse<AppointmentModel>
            {
                IsSuccessful = false,
                Message = $"Failed to insert appointment with message: {ex.Message}, inner exception: {ex.InnerException?.Message}",
            };
        }
    }
}
