using FluentValidation;
using PhoneBook.DTO.PrivateOrganizationDtos;

namespace PhoneBook.BLL.Validators.PrivateOrganizationValidators
{
    public class CreatePrivateOrganizationValidator : AbstractValidator<CreatePrivateOrganizationDto>
    {
        public CreatePrivateOrganizationValidator()
        {
            RuleFor(x => x.TaxId)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.OrganizationType)
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
