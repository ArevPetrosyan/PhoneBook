﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DTO.ContactDtos
{
    public class ContactDto : BaseDeleteDtoWithDate
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string TextComment { get; set; }

        public long ContactTypeId { get; set; }
        public ContactTypeDto? ContactType { get; set; }
    }
}