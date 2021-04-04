using Application.Dtos;
using FluentValidation;

namespace Application.Validation
{
    public class BasketValidator : AbstractValidator<BasketDto>
    {
        public BasketValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id field is required");
            RuleForEach(x => x.Items).SetValidator(new BasketItemValidator());
        }
    }
}
