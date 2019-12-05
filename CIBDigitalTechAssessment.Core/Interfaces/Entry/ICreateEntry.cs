using CIBDigitalTechAssessment.Core.Dtos.Requests.Entry;
using CIBDigitalTechAssessment.Core.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIBDigitalTechAssessment.Core.Interfaces.Entry
{
    public interface ICreateEntry : IRequestHandler<CreateEntryRequest, ServiceResponse>
    {
    }
}
