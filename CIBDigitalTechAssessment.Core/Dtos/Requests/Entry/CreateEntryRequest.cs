using CIBDigitalTechAssessment.Core.Dtos.Response;
using CIBDigitalTechAssessment.Core.Interfaces;

namespace CIBDigitalTechAssessment.Core.Dtos.Requests.Entry
{
    public class CreateEntryRequest : IRequest<ServiceResponse>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneBookId { get; set; }
        public CreateEntryRequest(string name, string phoneNumber, int phoneBookId)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            PhoneBookId = phoneBookId;
        }
    }
}