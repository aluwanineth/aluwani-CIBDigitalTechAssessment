﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIBDigitalTechAssessment.WebApi.Models.Requests.PhoneBook
{
    public class GetPhoneBookEntryByNameRequest
    {
        public int PhoneBookId { get; set; }
        public string Name { get; set; }
    }
}
