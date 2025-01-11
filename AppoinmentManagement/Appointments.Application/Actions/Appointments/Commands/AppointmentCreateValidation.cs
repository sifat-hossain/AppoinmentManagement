namespace Appointments.Application.Actions.Appointments.Commands;

public class AppointmentCreateValidation : AbstractValidator<AppointmentCreateCommand>
{
    public AppointmentCreateValidation()
    {
        RuleFor(r => r.PatientName)
            .NotEmpty()
            .MaximumLength(Constants.FieldSize.Name);

        RuleFor(r => r.AppointmentDateTime)
                   .NotEmpty()
                   .GreaterThan(DateTime.UtcNow);
    }
}
