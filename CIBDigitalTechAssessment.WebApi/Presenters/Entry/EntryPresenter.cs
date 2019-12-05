using CIBDigitalTechAssessment.Core.Dtos.Response;
using CIBDigitalTechAssessment.Core.Interfaces;
using CIBDigitalTechAssessment.WebApi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CIBDigitalTechAssessment.WebApi.Presenters.Entry
{
    public class EntryPresenter : IOutputPort<ServiceResponse>
    {
        public JsonContentResult ContentResult { get; }

        public EntryPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(ServiceResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
