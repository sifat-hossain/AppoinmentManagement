namespace Appoinments.Application.Actions.Appoinments.Query.PullAppoinmentList;

public class AppoinmentQueryRequest : IRequest<List<AppoinmentModel>>
{
    public int? Skip { get; set; }
    public int? Take { get; set; }
}
