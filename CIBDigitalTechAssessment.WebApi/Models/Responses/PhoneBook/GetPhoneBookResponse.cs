using CIBDigitalTechAssessment.Core.Dtos.Responses.PhoneBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIBDigitalTechAssessment.WebApi.Models.Responses.PhoneBook
{
    public class GetPhoneBookResponse
    {
         public IEnumerable<PhoneBookDto> PhoneBooks { get; }

        public GetPhoneBookResponse(IEnumerable<PhoneBookDto> phoneBooks)
        {
            PhoneBooks = phoneBooks;
        }
    }
}
