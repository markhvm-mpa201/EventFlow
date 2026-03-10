using EventFlow.Business.Dtos.UserDtos;
using FluentValidation;

namespace EventFlow.Business.Validators.UserValidators;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .MaximumLength(256).WithMessage("Email cannot exceed 256 characters.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Fullname)
            .NotEmpty().WithMessage("Full name is required.")
            .Length(2, 100).WithMessage("Full name must be between 2 and 100 characters.")
            .Matches("^[a-zA-Z\\s'-]+$")
            .WithMessage("Full name contains invalid characters.");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("User name is required.")
            .Length(3, 50).WithMessage("User name must be between 3 and 50 characters.")
            .Matches("^[a-zA-Z0-9_]+$")
            .WithMessage("User name can contain only letters, numbers, and underscores.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .MaximumLength(100).WithMessage("Password cannot exceed 100 characters.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one number.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Confirm password is required.")
            .Equal(x => x.Password).WithMessage("Passwords do not match.");
    }
}