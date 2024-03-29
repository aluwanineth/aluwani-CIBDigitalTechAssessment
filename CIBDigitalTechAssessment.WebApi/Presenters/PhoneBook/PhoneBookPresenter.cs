﻿using CIBDigitalTechAssessment.Core.Dtos.Response;
using CIBDigitalTechAssessment.Core.Dtos.Responses.PhoneBook;
using CIBDigitalTechAssessment.Core.Interfaces;
using CIBDigitalTechAssessment.WebApi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CIBDigitalTechAssessment.WebApi.Presenters.PhoneBook
{
    public class PhoneBookPresenter : IOutputPort<ServiceResponse>, IOutputPort<GetPhoneBookResponse>
    {
        public JsonContentResult ContentResult { get; }

        public PhoneBookPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(ServiceResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }

        public void Handle(GetPhoneBookResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(new Models.Responses.PhoneBook.GetPhoneBookResponse(response.PhoneBooks)) : JsonSerializer.SerializeObject(response.Message);
        }
    }
}