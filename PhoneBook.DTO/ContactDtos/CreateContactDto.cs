﻿namespace PhoneBook.DTO.ContactDtos
{
    public class CreateContactDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string TextComment { get; set; }
        public long ContactTypeId { get; set; }
    }
}
