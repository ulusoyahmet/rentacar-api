using FluentValidation;
using RentACarAPI.Application.Features.Mediator.Commands.ReviewCommands;

namespace RentACarAPI.Application.Validators.ReviewValidators
{
    public class UpdateReviewValidator: AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty()
                .WithMessage("Please fill Customer Name field.")
                .MinimumLength(4)
                .WithMessage("Please enter a least 4 characters.");

            RuleFor(x => x.Rating)
                .NotEmpty()
                .WithMessage("Please give a rationg");

            RuleFor(x => x.Comment)
                .NotEmpty()
                .WithMessage("Please enter your review")
                .Length(15, 500)
                .WithMessage("Your review should be at between 15-500 chracters");


        }
    }
}
