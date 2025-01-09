namespace Appoinments.Application.Actions.Appoinments.Query.PullAppoinmentList;

public class AppoinmentQueryHandler(IAppoinmentDbContext appointmentDbContext) :
    IRequestHandler<AppoinmentQueryRequest, List<AppoinmentModel>>
{
    private readonly IAppoinmentDbContext _appointmentDbContext = appointmentDbContext;

    public async Task<List<AppoinmentModel>> Handle(AppoinmentQueryRequest request, CancellationToken cancellationToken)
    {
        int skip = request.Skip ?? 0;
        int take = request.Take ?? 20;

        List<Appointment> categories = await _appointmentDbContext.Appointment
            .Skip(skip)
            .Take(take)
            .Include(x => x.Doctor)
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x => x.CreatedOn)
            .ToListAsync(cancellationToken: cancellationToken);

        return categories.Count <= 0 ? [] : categories.Select(p => AppoinmentModel.Create(p)).ToList();
    }
}
