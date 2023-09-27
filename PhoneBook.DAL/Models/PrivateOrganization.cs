using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DAL.Models
{
    public class PrivateOrganization : BaseEntity
    {
        public string OrganizationType { get; set; }

        public string TaxId { get; set; }
        public long ContactId { get; set; }
        public Contact? Contact { get; set; }
    }
}
