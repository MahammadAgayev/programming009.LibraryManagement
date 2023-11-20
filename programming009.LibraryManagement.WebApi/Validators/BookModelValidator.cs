using FluentValidation;

using programming009.LibraryManagement.Core.Domain.Enums;
using programming009.LibraryManagement.WebApi.Models;

namespace programming009.LibraryManagement.WebApi.Validators
{
    public class BookModelValidator : AbstractValidator<BookModel>
    {
        public BookModelValidator()
        {
            this.RuleFor(x => x.Name).NotNull()
                .NotEmpty().WithMessage("Book name should be provided");

            //price > 0 && price <= 1000
            this.RuleFor(x => x.Price).NotNull().NotEmpty()
                .GreaterThan(0)
                .LessThanOrEqualTo(1000);

            this.RuleFor(x => x.Genre).NotNull().NotEmpty()
                .IsInEnum();
        }
    }
}
