using FluentValidation;
using LibrarySystem.Models.Requests;

namespace LibrarySystem.Common.Validators;

public class AddBookValidator : AbstractValidator<AddBookRequest>
{
    public AddBookValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.Author).NotEmpty().WithMessage("Author is required");
        RuleFor(x => x.Year).GreaterThan(0).WithMessage("Year must be greater than 0");
    }
}

