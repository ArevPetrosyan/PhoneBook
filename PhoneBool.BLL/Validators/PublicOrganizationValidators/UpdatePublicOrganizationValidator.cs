using FluentValidation;
using PhoneBook.DTO.PublicOrganizationDtos;
using PhoneBook.Shared;

namespace PhoneBook.BLL.Validators.PublicOrganizationValidators
{
    public class UpdatePublicOrganizationValidator : AbstractValidator<UpdatePublicOrganizationDto>
    {
        public UpdatePublicOrganizationValidator()
        {
            RuleFor(x => x.PublicInfo)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Website)
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
