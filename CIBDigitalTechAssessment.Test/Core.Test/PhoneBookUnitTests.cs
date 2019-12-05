using CIBDigitalTechAssessment.Core.Dtos.Requests.PhoneBook;
using CIBDigitalTechAssessment.Core.Dtos.Response;
using CIBDigitalTechAssessment.Core.Dtos.Response.GatewayResponses.Repositories;
using CIBDigitalTechAssessment.Core.Dtos.Responses.PhoneBook;
using CIBDigitalTechAssessment.Core.Interfaces;
using CIBDigitalTechAssessment.Core.Interfaces.Gateways.Repositories;
using CIBDigitalTechAssessment.Core.Services.PhoneBook;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CIBDigitalTechAssessment.Test.Core.Test
{
    public class PhoneBookUnitTests
    {
        [Fact]
        public async void Handle_GivenValidPhoneBookDetails_CreatePhoneBook_ShouldSucceed()
        {
            var mockUserRepository = new Mock<IPhoneBookRepository>();
            mockUserRepository
              .Setup(repo => repo.Create(It.IsAny<string>()))
              .ReturnsAsync(new Response("", true));
             
            var phoneBook = new PhoneBookService(mockUserRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<ServiceResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<ServiceResponse>()));

            var response = await phoneBook.Handle(new CreatePhoneBookRequest("Aluwani Phone Book"), mockOutputPort.Object);

            Assert.True(response);
        }

        [Fact]
        public async void GivenValidEntryName_shouldSucced()
        {
            List<PhoneBookDto> fakeResponse = new List<PhoneBookDto>();
            PhoneBookDto fakeDataResponse = new PhoneBookDto
            {
                Entry = null,
                Id = 1,
                PhoneBookName = "Aluwani"
            };
            fakeResponse.Add(fakeDataResponse);
            var mockUserRepository = new Mock<IPhoneBookRepository>();
            mockUserRepository.Setup(repo => repo.GetPhoneBookEntryByName(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync(fakeResponse);

            var phoneBookService = new PhoneBookService(mockUserRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetPhoneBookResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetPhoneBookResponse>()));

        
            var response = await phoneBookService.Handle(new GetPhoneBookEntryByNameRequest(1,"Aluwani"), mockOutputPort.Object);

            // assert
            Assert.True(response);
        }

        [Fact]
        public async void GivenValidPhoneName_shouldSucced()
        {
            List<PhoneBookDto> fakeResponse = new List<PhoneBookDto>();
            PhoneBookDto fakeDataResponse = new PhoneBookDto
            {
                Entry = null,
                Id = 1,
                PhoneBookName = "Aluwani"
            };
            fakeResponse.Add(fakeDataResponse);
            var mockUserRepository = new Mock<IPhoneBookRepository>();
            mockUserRepository.Setup(repo => repo.GetPhoneBookEntryByName(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync(fakeResponse);

            var phoneBookService = new PhoneBookService(mockUserRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<GetPhoneBookResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetPhoneBookResponse>()));


            var response = await phoneBookService.Handle(new GetPhoneBookRequest(), mockOutputPort.Object);

            // assert
            Assert.True(response);
        }
    }
}
