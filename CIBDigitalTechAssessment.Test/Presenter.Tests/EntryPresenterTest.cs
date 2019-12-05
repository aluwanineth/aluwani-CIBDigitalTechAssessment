using CIBDigitalTechAssessment.Core.Dtos.Response;
using CIBDigitalTechAssessment.WebApi.Presenters.Entry;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace CIBDigitalTechAssessment.Test.Presenter.Tests
{
    public class EntryPresenterTest
    {
        [Fact]
        public void Handle_GivenSuccessfulEntryResponse_SetsOKHttpStatusCode()
        {
            var presenter = new EntryPresenter();

            presenter.Handle(new ServiceResponse("", true));

            Assert.Equal((int)HttpStatusCode.OK, presenter.ContentResult.StatusCode);
        }
    }
}
