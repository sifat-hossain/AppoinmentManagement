namespace Appoinments.Application.Actions.Doctors.Commands;

public class DoctorCreateValidation : AbstractValidator<DoctorCreateCommand>
{
    public DoctorCreateValidation()
    {
        RuleFor(r => r.DoctorName)
            .NotEmpty()
            .MaximumLength(Constants.FieldSize.Name);
    }
}
