using CIBDigitalTechAssessment.Core.Dtos.Requests.Entry;
using CIBDigitalTechAssessment.Core.Dtos.Response;
using CIBDigitalTechAssessment.Core.Dtos.Response.GatewayResponses.Repositories;
using CIBDigitalTechAssessment.Core.Interfaces;
using CIBDigitalTechAssessment.Core.Interfaces.Gateways.Repositories;
using CIBDigitalTechAssessment.Core.Services.Entry;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CIBDigitalTechAssessment.Test.Core.Test
{
    public class EntryUnitTests
    {
        [Fact]
        public async void Handle_GivenValidEntryDetails_CreateEntry_ShouldSucceed()
        {
            var mockUserRepository = new Mock<IEntryRepository>();
            mockUserRepository
              .Setup(repo => repo.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
              .ReturnsAsync(new Response("", true));

            var phoneBook = new EntryService(mockUserRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<ServiceResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<ServiceResponse>()));

            var response = await phoneBook.Handle(new CreateEntryRequest("Aluwani Nethavhakone", "0813675364",1), mockOutputPort.Object);

            // assert
            Assert.True(response);
        }
    }
}
