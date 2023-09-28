using FluentValidation;
using PhoneBook.DTO.PersonDtos;

namespace PhoneBook.BLL.Validators.PersonDtoValidators
{
    public class CreatePersonDtoValidator : AbstractValidator<CreatePersonDto>
    {
        public CreatePersonDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Address)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.ContactTypeId)
                .NotEmpty();
        }
    }
}
