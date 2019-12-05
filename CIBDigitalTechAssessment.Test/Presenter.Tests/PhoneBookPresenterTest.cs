using CIBDigitalTechAssessment.Core.Dtos;
using CIBDigitalTechAssessment.Core.Dtos.Response;
using CIBDigitalTechAssessment.Core.Dtos.Responses.PhoneBook;
using CIBDigitalTechAssessment.WebApi.Presenters.PhoneBook;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;

namespace CIBDigitalTechAssessment.Test.Presenter.Tests
{
    public class PhoneBookPresenterTest
    {
        [Fact]
        public void Handle_GivenSuccessfulPhoneBookResponse_SetsOKHttpStatusCode()
        {
            var presenter = new PhoneBookPresenter();

            presenter.Handle(new ServiceResponse("", true));

            Assert.Equal((int)HttpStatusCode.OK, presenter.ContentResult.StatusCode);
        }

        [Fact]
        public void Handle_GivenSuccessfulPhoneBookResponse_GetPhoneBooks()
        {
            List<PhoneBookDto> fakeList = new List<PhoneBookDto>();
            PhoneBookDto fakeDataResponse = new PhoneBookDto
            {
                Entry = null,
                Id = 1,
                PhoneBookName = "Aluwani"
            };
            fakeList.Add(fakeDataResponse);
            var presenter = new PhoneBookPresenter();

            presenter.Handle(new GetPhoneBookResponse(fakeList, true));

            dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);
            Assert.Equal(fakeList, data);
        }

        [Fact]
        public void Handle_GivenFailedPhoneBookResponse_SetsErrors()
        {
            var presenter = new PhoneBookPresenter();
            Error error = new Error("400", "Invalid model");
            var fakeError = new List<Error>() { error };
            //presenter.Handle(new ServiceResponse(fakeError));
            var data = JsonConvert.DeserializeObject<IEnumerable<Error>>(presenter.ContentResult.Content);
            Assert.Equal((int)HttpStatusCode.BadRequest, presenter.ContentResult.StatusCode);
            Assert.Equal("Invalid username/password", data.First().Description);
        }
    }
}
