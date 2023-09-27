using FluentValidation;
using PhoneBook.DTO.PublicOrganizationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Validators.PublicOrganizationValidators
{
    public class CreatePublicOrganizationValidator : AbstractValidator<CreatePublicOrganizationDto>
    {
        public CreatePublicOrganizationValidator()
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
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.ContactTypeId)
                .NotEmpty();
        }
    }
}
