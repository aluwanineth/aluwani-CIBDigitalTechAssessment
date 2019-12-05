using System.Collections.Generic;

namespace CIBDigitalTechAssessment.Core.Dtos.Responses.GatewayResponses
{
  public abstract class BaseGatewayResponse
  {
    public bool Success { get; }
    public IEnumerable<Error> Errors { get; }

    protected BaseGatewayResponse(bool success=false, IEnumerable<Error> errors=null)
    {
      Success = success;
      Errors = errors;
    }
  }
}

