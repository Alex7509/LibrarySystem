using FluentValidation;
using LibrarySystem.Models.Requests;

namespace LibrarySystem.Common.Validators;

public class AddMemberValidator : AbstractValidator<AddMemberRequest>
{
    public AddMemberValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Valid email is required");
    }
}
