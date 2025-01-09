namespace Appoinments.Application.Actions.Appoinments.Commands;

public class AppoinmentCreateValidation : AbstractValidator<AppoinmentCreateCommand>
{
    public AppoinmentCreateValidation()
    {
        RuleFor(r => r.PatientName)
            .NotEmpty()
            .MaximumLength(Constants.FieldSize.Name);

        RuleFor(r => r.AppointmentDateTime)
                   .NotEmpty()
                   .GreaterThan(DateTime.UtcNow);
    }
}
