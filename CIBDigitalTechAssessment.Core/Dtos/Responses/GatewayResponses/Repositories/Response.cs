using CIBDigitalTechAssessment.Core.Dtos.Responses.GatewayResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIBDigitalTechAssessment.Core.Dtos.Response.GatewayResponses.Repositories
{
    public sealed class Response : BaseGatewayResponse
    {
        public string Id { get; }
        public Response(string id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}
