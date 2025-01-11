namespace Appointments.Application.Actions.Appointments.Query.PullAppointmentList;

public class AppointmentQueryHandler(IAppointmentDbContext appointmentDbContext) :
    IRequestHandler<AppointmentQueryRequest, List<AppointmentModel>>
{
    private readonly IAppointmentDbContext _appointmentDbContext = appointmentDbContext;

    public async Task<List<AppointmentModel>> Handle(AppointmentQueryRequest request, CancellationToken cancellationToken)
    {
        int skip = request.Skip ?? 0;
        int take = request.Take ?? 20;

        List<Appointment> appointments = await _appointmentDbContext.Appointment
            .Skip(skip)
            .Take(take)
            .Include(x => x.Doctor)
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x => x.CreatedOn)
            .ToListAsync(cancellationToken: cancellationToken);

        return appointments.Count <= 0 ? [] : appointments.Select(p => AppointmentModel.Create(p)).ToList();
    }
}
