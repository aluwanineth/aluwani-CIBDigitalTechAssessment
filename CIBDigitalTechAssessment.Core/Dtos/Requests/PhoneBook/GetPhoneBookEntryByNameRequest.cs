using CIBDigitalTechAssessment.Core.Dtos.Responses.PhoneBook;
using CIBDigitalTechAssessment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIBDigitalTechAssessment.Core.Dtos.Requests.PhoneBook
{
    public class GetPhoneBookEntryByNameRequest : IRequest<GetPhoneBookResponse>
    {
        public int PhoneBookId { get; set; }
        public string Name { get; set; }

        public GetPhoneBookEntryByNameRequest(int phoneBookId, string name)
        {
            PhoneBookId = phoneBookId;
            Name = name;
        }
    }
}
