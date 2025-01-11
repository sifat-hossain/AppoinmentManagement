namespace Appointments.Application.Actions.Appointments.Commands.Delete;

public class AppointmentDeleteHandler(IAppointmentDbContext appointmentDbContext) :
    IRequestHandler<AppointmentDeleteCommand, AppointmentResponse>
{
    private readonly IAppointmentDbContext _appointmentDbContext = appointmentDbContext;

    public async Task<AppointmentResponse> Handle(AppointmentDeleteCommand request, CancellationToken cancellationToken)
    {

        Appointment? appointment = await _appointmentDbContext.Appointment
            .Include(x => x.Doctor)
            .Where(x => !x.IsDeleted && x.Id == request.Id)
            .OrderByDescending(x => x.CreatedOn)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        if (appointment != null)
        {
            appointment.IsDeleted = true;
            _appointmentDbContext.Appointment.Update(appointment);
            _appointmentDbContext.SaveChanges();
            return new AppointmentResponse
            {
                IsSuccessful = true,
                Message = ""
            };
        }
        return new AppointmentResponse
        {
            IsSuccessful = false,
            Message = "This appointment is not available"
        };
    }
}
