using FluentValidation;
using RentACarAPI.Application.Features.Mediator.Commands.ReviewCommands;

namespace RentACarAPI.Application.Validators.ReviewValidators
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty()
                .WithMessage("Please fill Customer Name field.")
                .MinimumLength(5)
                .WithMessage("Customer Name field must be at least 5 characters.");

            RuleFor(x => x.Rating)
                .NotEmpty()
                .WithMessage("Please give a rating.");

            RuleFor(x => x.Comment)
                .NotEmpty()
                .WithMessage("Please enter your review.")
                .Length(15, 500)
                .WithMessage("Your review should be at between 15-500 chracters.");
        }
    }
}
