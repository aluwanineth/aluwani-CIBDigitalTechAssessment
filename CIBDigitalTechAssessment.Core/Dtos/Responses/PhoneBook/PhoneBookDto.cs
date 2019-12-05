using CIBDigitalTechAssessment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIBDigitalTechAssessment.Core.Dtos.Responses.PhoneBook
{
    public class PhoneBookDto
    {
        public int Id { get; set; }
        public string PhoneBookName { get; set; }
        public List<Entry> Entry { get; set; }
    }
}
