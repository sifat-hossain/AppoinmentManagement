namespace Appointments.Application.Actions.Appointments.Query.PullAppointmentById;

public class AppointmentByIdQueryHandler(IAppointmentDbContext appointmentDbContext) :
    IRequestHandler<AppointmentByIdQueryRequest, AppointmentModel>
{
    private readonly IAppointmentDbContext _appointmentDbContext = appointmentDbContext;

    public async Task<AppointmentModel> Handle(AppointmentByIdQueryRequest request, CancellationToken cancellationToken)
    {

        Appointment? appointment = await _appointmentDbContext.Appointment
            .Include(x => x.Doctor)
            .Where(x => !x.IsDeleted && x.Id == request.Id)
            .OrderByDescending(x => x.CreatedOn)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return appointment == null ? throw new Exception("Appoinment is not found") : AppointmentModel.Create(appointment);
    }
}
