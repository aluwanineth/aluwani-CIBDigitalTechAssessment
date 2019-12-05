using CIBDigitalTechAssessment.Core.Dtos.Response;
using CIBDigitalTechAssessment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIBDigitalTechAssessment.Core.Dtos.Requests.PhoneBook
{
    public class CreatePhoneBookRequest : IRequest<ServiceResponse>
    {
        public string Name { get; set; }
       
        public CreatePhoneBookRequest(string name)
        {
            Name = name;
        }
    }
}