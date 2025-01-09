﻿using FluentValidation;

namespace Users.Application.Actions.Users.Commands.LoginUser
{
    public class LoginUserValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserValidator()
        {
            RuleFor(r => r.UserName)
                .NotEmpty();
        }
    }
}