using CIBDigitalTechAssessment.Core.Dtos.Requests.PhoneBook;
using CIBDigitalTechAssessment.Core.Dtos.Response;
using CIBDigitalTechAssessment.Core.Dtos.Responses.PhoneBook;
using CIBDigitalTechAssessment.Core.Interfaces;
using CIBDigitalTechAssessment.Core.Interfaces.Gateways.Repositories;
using CIBDigitalTechAssessment.Core.Interfaces.PhoneBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIBDigitalTechAssessment.Core.Services.PhoneBook
{
    public sealed class PhoneBookService : ICreatePhoneBook, IGetPhoneBooks, IGetPhoneBookEntryByName
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public PhoneBookService(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }
        public async Task<bool> Handle(CreatePhoneBookRequest message, IOutputPort<ServiceResponse> outputPort)
        {
            var response = await _phoneBookRepository.Create(message.Name);
            outputPort.Handle(response.Success ? new ServiceResponse(response.Id, true) : new ServiceResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }

        public async Task<bool> Handle(GetPhoneBookRequest message, IOutputPort<GetPhoneBookResponse> outputPort)
        {
            var response = await _phoneBookRepository.GetPhoneBooks();
            outputPort.Handle(new GetPhoneBookResponse(response, true, null));

            return true;
        }

        public async Task<bool> Handle(GetPhoneBookEntryByNameRequest message, IOutputPort<GetPhoneBookResponse> outputPort)
        {
            var response = await _phoneBookRepository.GetPhoneBookEntryByName(message.PhoneBookId,message.Name);
            outputPort.Handle(new GetPhoneBookResponse(response, true, null));

            return true;
        }
    }
}
