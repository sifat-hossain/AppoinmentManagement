namespace Appoinments.Application.Actions.Appoinments.Query.PullAppoinmentById;

public class AppoinmentByIdQueryRequest : IRequest<AppoinmentModel>
{
    /// <summary>Gets or sets the category identifier.</summary>
    /// <value>The category identifier.</value>
    public int Id { get; set; }
}
