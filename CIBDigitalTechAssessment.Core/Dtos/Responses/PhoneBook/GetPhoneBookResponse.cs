using CIBDigitalTechAssessment.Core.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIBDigitalTechAssessment.Core.Dtos.Responses.PhoneBook
{
    public class GetPhoneBookResponse : ResponseMessage
    {
        public IEnumerable<PhoneBookDto> PhoneBooks { get; }
        public GetPhoneBookResponse(IEnumerable<PhoneBookDto> phoneBooks, bool success = false, string message = null) : base(success, message)
        {
            PhoneBooks = phoneBooks;
        }
    }
}