using CIBDigitalTechAssessment.Core.Dtos.Requests.PhoneBook;
using CIBDigitalTechAssessment.Core.Dtos.Responses.PhoneBook;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIBDigitalTechAssessment.Core.Interfaces.PhoneBook
{
    public interface IGetPhoneBookEntryByName : IRequestHandler<GetPhoneBookEntryByNameRequest, GetPhoneBookResponse>
    {
    }
}
