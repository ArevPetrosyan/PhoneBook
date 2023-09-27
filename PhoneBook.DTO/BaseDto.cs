using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DTO
{
    public class BaseDto
    {
        public long Id { get; set; }
    }

    public class BaseDtoWithDate : BaseDto
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }

    public class BaseDeleteDtoWithDate : BaseDtoWithDate
    {
        public bool IsDeleted { get; set; }
    }

    public class BaseModelDto : BaseDto
    {
        public string Name { get; set; }
    }
}
