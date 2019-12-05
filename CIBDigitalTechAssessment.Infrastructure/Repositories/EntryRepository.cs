using CIBDigitalTechAssessment.Core.Dtos;
using CIBDigitalTechAssessment.Core.Dtos.Response.GatewayResponses.Repositories;
using CIBDigitalTechAssessment.Core.Entities;
using CIBDigitalTechAssessment.Core.Interfaces.Gateways.Repositories;
using CIBDigitalTechAssessment.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIBDigitalTechAssessment.Infrastructure.Repositories
{
    public class EntryRepository : EfRepository<Entry>, IEntryRepository
    {
        public EntryRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public async Task<Response> Create(string name, string phoneNumber, int phoneBookId)
        {
            try
            {
                var entry = new Entry(name, phoneNumber, phoneBookId);
                await Add(entry);
                return new Response(Guid.NewGuid().ToString(), true, null);
            }
            catch (Exception ex)
            {
                List<Error> errors = new List<Error>();
                var error = new Error("500", ex.Message);
                errors.Add(error);
                return new Response(Guid.NewGuid().ToString(), true, errors.Select(e => new Error(e.Code, e.Description)));
            }
        }
    }
}
