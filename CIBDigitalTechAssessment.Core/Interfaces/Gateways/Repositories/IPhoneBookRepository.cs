using CIBDigitalTechAssessment.Core.Dtos.Response.GatewayResponses.Repositories;
using CIBDigitalTechAssessment.Core.Dtos.Responses.PhoneBook;
using CIBDigitalTechAssessment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIBDigitalTechAssessment.Core.Interfaces.Gateways.Repositories
{
    public interface IPhoneBookRepository : IRepository<Entities.PhoneBook>
    {
        Task<Response> Create(string name);
        Task<IEnumerable<PhoneBookDto>> GetPhoneBooks();
        Task<IEnumerable<PhoneBookDto>> GetPhoneBookEntryByName(int phoneId, string name);
    }
}
