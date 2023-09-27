using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DAL.Models
{
    public class PublicOrganization : BaseEntity
    {
        public string Website { get; set; }
        public string PublicInfo { get; set; }
        public long ContactId { get; set; }
        public Contact? Contact { get; set; }
    }
}
