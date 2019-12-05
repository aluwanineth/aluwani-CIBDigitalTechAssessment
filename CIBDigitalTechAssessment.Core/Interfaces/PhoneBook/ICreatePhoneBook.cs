using CIBDigitalTechAssessment.Core.Dtos.Requests.PhoneBook;
using CIBDigitalTechAssessment.Core.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIBDigitalTechAssessment.Core.Interfaces.PhoneBook
{
    public interface ICreatePhoneBook : IRequestHandler<CreatePhoneBookRequest, ServiceResponse>
    {
    }
}
