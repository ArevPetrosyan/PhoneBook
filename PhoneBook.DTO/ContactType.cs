using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DTO
{
    public class ContactTypeDto : BaseDeleteDtoWithDate
    {
        public string Name { get; set; }
    }
}
