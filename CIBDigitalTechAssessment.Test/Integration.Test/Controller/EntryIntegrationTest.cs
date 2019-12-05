using CIBDigitalTechAssessment.Core.Dtos.Requests.Entry;
using CIBDigitalTechAssessment.Core.Dtos.Requests.PhoneBook;
using CIBDigitalTechAssessment.WebApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CIBDigitalTechAssessment.Test.Integration.Test.Controller
{
    public class EntryIntegrationTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public EntryIntegrationTest(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }
        [Fact]
        public async Task CanCreatePhoneBookWithValidInputDetails()
        {
            var httpResponse = await _client.PostAsync("/api/entries", new StringContent(JsonConvert
                        .SerializeObject(new CreateEntryRequest("Aluwani", "081234567",1)), Encoding.UTF8, "application/json"));
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            dynamic result = JObject.Parse(stringResponse);
            Assert.True((bool)result.success);
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [Fact]
        public async Task CantCreatePhoneBookWithInvalidInputDetails()
        {
            var httpResponse = await _client.PostAsync("/api/entries", new StringContent(JsonConvert
                .SerializeObject(new CreateEntryRequest(null,null,0)), Encoding.UTF8, "application/json"));
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Contains("'Name' must not be empty.", stringResponse);
            Assert.Equal(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

    }
}
