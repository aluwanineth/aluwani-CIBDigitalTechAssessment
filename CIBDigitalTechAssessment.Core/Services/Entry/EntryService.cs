using CIBDigitalTechAssessment.Core.Dtos.Requests.Entry;
using CIBDigitalTechAssessment.Core.Dtos.Response;
using CIBDigitalTechAssessment.Core.Interfaces;
using CIBDigitalTechAssessment.Core.Interfaces.Entry;
using CIBDigitalTechAssessment.Core.Interfaces.Gateways.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIBDigitalTechAssessment.Core.Services.Entry
{
    public sealed class EntryService : ICreateEntry
    {
        private readonly IEntryRepository _entryRepository;

        public EntryService(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public async Task<bool> Handle(CreateEntryRequest message, IOutputPort<ServiceResponse> outputPort)
        {
            var response = await _entryRepository.Create(message.Name, message.PhoneNumber, message.PhoneBookId);
            outputPort.Handle(response.Success ? new ServiceResponse(response.Id, true) : new ServiceResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
