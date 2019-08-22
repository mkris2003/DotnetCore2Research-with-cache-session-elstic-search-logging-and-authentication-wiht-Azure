using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DotnetCore2Research;
using Xunit;
using DotnetCore2Research.Classes;
using Newtonsoft.Json.Linq;
using System.IO;
using static DotnetCore2Research.IntegrationTests.ContentHelper;
using System.Net.Http.Headers;
using static DotnetCore2Research.BL.MiddleWare.AuthenticationTocken;
namespace DotnetCore2Research.IntegrationTests
{
   public class EmployeeIntegrationTestes : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public EmployeeIntegrationTestes(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetCountryAsync()
        {
            var jwtToken = GenerateToken();
            // Arrange
            var url = "/api/Employee/GetSession";
            var req = new HttpRequestMessage(HttpMethod.Get, url); 
            req.Headers.Add("APIKEY", jwtToken);
            var response = await Client.SendAsync(req);
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();
            jsonFromPostResponse = JToken.Parse(jsonFromPostResponse).ToString();
            var singleResponse = JsonConvert.DeserializeObject<Country>(jsonFromPostResponse);
            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task DeleteCityDetails()
        {
            var jwtToken = GenerateToken();
            int cityId = 9;
            // Arrange
            var url = "/api/Employee/DeleteCityDetails/"+ cityId;
            var req = new HttpRequestMessage(HttpMethod.Delete, url);
            req.Headers.Add("APIKEY", jwtToken);
            var response = await Client.SendAsync(req);
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();
            
            // Assert
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task GetCityDetails()
        {
            int countryId=1, stateId = 1;
            var jwtToken = GenerateToken();
            // Arrange
            var url = "/api/Employee/GetCityDetails/" + countryId+"/"+ stateId;
            var req = new HttpRequestMessage(HttpMethod.Get, url);
            req.Headers.Add("APIKEY", jwtToken);
            var response = await Client.SendAsync(req);
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();
            
            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [ClassData(typeof(EmployeeTestData))]
        public async Task GetEmployeeDetails(Employee emp1, Employee emp2)
        {
            var jwtToken = GenerateToken();
            // Arrange
            var url = "/api/Employee/GetEmployeeDetails" ;
            var req = new HttpRequestMessage(HttpMethod.Post, url);
            req.Headers.Add("APIKEY", jwtToken);
            req .Content= CreateHttpContent(emp1);
            var response = await Client.SendAsync(req);
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();

          
        }

        [Theory]
        [ClassData(typeof(CountryTestData))]
        public async Task InsertCountryDetails(Country country)
        {
            var jwtToken = GenerateToken();
            // Arrange
            var url = "/api/Employee/InsertCountryDetails";
            var req = new HttpRequestMessage(HttpMethod.Put, url);
            req.Headers.Add("APIKEY", jwtToken);
            req.Content = CreateHttpContent(country);
            var response = await Client.SendAsync(req);
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();


        }
        [Fact]
        public async Task TestJwtTocken()
        {
            var jwtToken =GenerateToken();
            var url = "/api/Employee/GetSession";
            var req = new HttpRequestMessage(HttpMethod.Get, url);
            req.Headers.Add("APIKEY",  jwtToken);
            var response = await Client.SendAsync(req);
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();
            jsonFromPostResponse = JToken.Parse(jsonFromPostResponse).ToString();
            var singleResponse = JsonConvert.DeserializeObject<Country>(jsonFromPostResponse);
            // Assert
            response.EnsureSuccessStatusCode();
        }

    }
}
