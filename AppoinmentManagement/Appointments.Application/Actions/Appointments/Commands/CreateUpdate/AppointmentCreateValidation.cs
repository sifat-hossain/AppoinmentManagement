namespace Appointments.Application.Actions.Appointments.Commands.CreateUpdate;

public class AppointmentCreateValidation : AbstractValidator<AppointmentCreateCommand>
{
    public AppointmentCreateValidation()
    {
        RuleFor(r => r.PatientName)
            .NotEmpty()
            .WithMessage("Patient Name is required.")
            .MaximumLength(Constants.FieldSize.Name);

        RuleFor(r => r.AppointmentDateTime)
            .NotEmpty()
            .WithMessage("Appointment date and time is required.")
            .GreaterThan(DateTime.Now)
            .WithMessage("Appointment date and time must be in the future.");
    }
}
