
namespace Appoinments.Application.Actions.Appoinments.Query.PullAppoinmentById;

public class AppoinmentByIdQueryHandler(IAppoinmentDbContext appointmentDbContext) :
    IRequestHandler<AppoinmentByIdQueryRequest, AppoinmentModel>
{
    private readonly IAppoinmentDbContext _appointmentDbContext = appointmentDbContext;

    public async Task<AppoinmentModel> Handle(AppoinmentByIdQueryRequest request, CancellationToken cancellationToken)
    {

        Appointment? category = await _appointmentDbContext.Appointment
            .Include(x => x.Doctor)
            .Where(x => !x.IsDeleted && x.Id == request.Id)
            .OrderByDescending(x => x.CreatedOn)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return category == null ? throw new Exception("Appoinment is not found") : AppoinmentModel.Create(category);
    }
}
