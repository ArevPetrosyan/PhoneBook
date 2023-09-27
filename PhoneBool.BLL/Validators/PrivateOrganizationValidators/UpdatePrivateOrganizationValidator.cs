using FluentValidation;
using PhoneBook.DTO.PrivateOrganizationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Validators.PrivateOrganizationValidators
{
    public class UpdatePrivateOrganizationValidator : AbstractValidator<UpdatePrivateOrganizationDto>
    {
        public UpdatePrivateOrganizationValidator()
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
