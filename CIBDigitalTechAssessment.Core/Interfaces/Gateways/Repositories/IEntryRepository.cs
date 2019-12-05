using CIBDigitalTechAssessment.Core.Dtos.Response.GatewayResponses.Repositories;
using CIBDigitalTechAssessment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIBDigitalTechAssessment.Core.Interfaces.Gateways.Repositories
{
    public interface IEntryRepository : IRepository<Entities.Entry>
    {
        Task<Response> Create(string name, string phoneNumber, int phoneBookId);
    }
}
