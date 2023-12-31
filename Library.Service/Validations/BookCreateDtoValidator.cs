using FluentValidation;
using Library.Core.DTOs.BookDTOs;

namespace Library.Service.Validations
{
    public class BookCreateDtoValidator : AbstractValidator<BookCreateDto>
    {
        public BookCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("{PropertyName} is required.");

            RuleFor(x => x.Author)
                .NotNull()
                .WithMessage("{PropertyName} is required.");
        }
    }
}
