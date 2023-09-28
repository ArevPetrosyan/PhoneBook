using FluentValidation;
using PhoneBook.DTO.PersonDtos;
using PhoneBook.Shared;

namespace PhoneBook.BLL.Validators.PersonDtoValidators
{
    public class UpdatePersonDtoValidator : AbstractValidator<UpdatePersonDto>
    {
        public UpdatePersonDtoValidator()
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
                .Matches(ValidationConstants.PhoneValidation)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.ContactTypeId)
                .NotEmpty();
        }
    }
}
