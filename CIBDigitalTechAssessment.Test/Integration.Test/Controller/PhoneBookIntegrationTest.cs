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
    public class PhoneBookIntegrationTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public PhoneBookIntegrationTest(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }
        [Fact]
        public async Task CanCreatePhoneBookWithValidInputDetails()
        {
            var httpResponse = await _client.PostAsync("/api/phoneBooks", new StringContent(JsonConvert
                        .SerializeObject(new CreatePhoneBookRequest("Aluwani")), Encoding.UTF8, "application/json"));
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            dynamic result = JObject.Parse(stringResponse);
            Assert.True((bool)result.success);
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [Fact]
        public async Task CantCreatePhoneBookWithInvalidInputDetails()
        {
            var httpResponse = await _client.PostAsync("/api/phoneBooks", new StringContent(JsonConvert
                .SerializeObject(new CreatePhoneBookRequest(null)), Encoding.UTF8, "application/json"));
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Contains("'Name' must not be empty.", stringResponse);
            Assert.Equal(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [Fact]
        public async Task CanGetPhoneBooks()
        {
            var httpResponse = await _client.GetAsync("/api/phoneBooks");
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            httpResponse.EnsureSuccessStatusCode();
            dynamic result = JObject.Parse(stringResponse);
            Assert.NotNull(result.phoneBooks.Id);
        }

        [Fact]
        public async Task CanGetPhoneBookentryByName()
        {
            string url = string.Format("/api/PhoneBooks/GetPhoneBookByName?phoneBookId={0}&name={1}", "1", "Aluwani Nethavhakone");
            var httpResponse = await _client.GetAsync(url);
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            httpResponse.EnsureSuccessStatusCode();
            dynamic result = JObject.Parse(stringResponse);
            Assert.NotNull(result.phoneBooks.Id);
        }

    }
}