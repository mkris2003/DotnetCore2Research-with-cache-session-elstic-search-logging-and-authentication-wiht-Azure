using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCore2Research.Azure.Classes;
using DotnetCore2Research.Azure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
namespace DotnetCore2Research.Azure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeProcess _employee = null;
        private readonly ILoggerFactory _loggerFactory = null;
        private readonly ILogger _logger = null;
        private readonly IDistributedCache _distributedCache = null;
        public EmployeeController(IEmployeeProcess employee, ILoggerFactory loggerFactory, IDistributedCache distributedCachecache)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<EmployeeController>();
            _employee = employee;
            _distributedCache = distributedCachecache;
        }


        /// <summary>
        /// This request will work from fiddler only
        /// https://localhost:44330/api/Employee/DeleteCityDetails/9
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>

        [Route("[action]/{cityId}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteCityDetails(int cityId)
        {
            await Task.Run(() => _employee.DeleteCityDetails(cityId)).ConfigureAwait(continueOnCapturedContext: false);
            return Ok();
        }
        [Route("[action]/{countryId}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteCountryDetails(int countryId)
        {
            await Task.Run(() => _employee.DeleteCountryDetails(countryId)).ConfigureAwait(continueOnCapturedContext: false);
            return Ok();
        }
        [Route("[action]/{employeeId}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteEmployeeDetails(int employeeId)
        {
            await Task.Run(() => _employee.DeleteEmployeeDetails(employeeId)).ConfigureAwait(continueOnCapturedContext: false);
            return Ok();
        }
        [Route("[action]/{stateId}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteStateDetails(int stateId)
        {
            await Task.Run(() => _employee.DeleteStateDetails(stateId)).ConfigureAwait(continueOnCapturedContext: false);
            return Ok();
        }

        [Route("[action]/{countryId}/{stateId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCityDetails(int countryId, int stateId)
        {
            var cityList = await Task.Run(() => _employee.GetCityDetails(countryId, stateId)).ConfigureAwait(continueOnCapturedContext: false);
            return Ok(cityList);
        }


        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountryDetails()
        {


            //_logger.LogInformation("OM");
            // throw new Exception("Exception while fetching all the students from the storage.");
            var countryList = await Task.Run(() => _employee.GetCountryDetails()).ConfigureAwait(continueOnCapturedContext: false);
            return Ok(countryList);
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeDetails([FromBody] Employee employee)
        {
            var employeeList = await Task.Run(() => _employee.GetEmployeeDetails(employee)).ConfigureAwait(continueOnCapturedContext: false);
            return Ok(employeeList);
        }
        [Route("[action]/{countryId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> GetStateDetails(int countryId)
        {
            var stateList = await Task.Run(() => _employee.GetStateDetails(countryId)).ConfigureAwait(continueOnCapturedContext: false);
            return Ok(stateList);
        }
        [Route("[action]")]
        [HttpPut]
        public async Task<ActionResult> InsertCityDetails([FromBody] City city)
        {
            await Task.Run(() => _employee.InsertCityDetails(city)).ConfigureAwait(continueOnCapturedContext: false);
            return Ok();
        }
        [Route("[action]")]
        [HttpPut]
        public async Task<ActionResult> InsertCountryDetails([FromBody] Country country)
        {
            await Task.Run(() => _employee.InsertCountryDetails(country)).ConfigureAwait(continueOnCapturedContext: false);
            return Ok();
        }
        [Route("[action]")]
        [HttpPut]
        public async Task<ActionResult> InsertEmployeeDetails([FromBody] Employee employee)
        {
            await Task.Run(() => _employee.InsertEmployeeDetails(employee)).ConfigureAwait(continueOnCapturedContext: false);
            return Ok();
        }

        [Route("[action]")]
        [HttpPut]
        public async Task<ActionResult> InsertStateDetails([FromBody] State state)
        {
            await Task.Run(() => _employee.InsertStateDetails(state)).ConfigureAwait(continueOnCapturedContext: false);
            return Ok();
        }
        [Route("[action]")]
        [HttpPut]
        public async Task<ActionResult> UpdateCityDetails([FromBody] City city)
        {
            await Task.Run(() => _employee.UpdateCityDetails(city)).ConfigureAwait(continueOnCapturedContext: false);
            return Ok();
        }
        [Route("[action]")]
        [HttpPut]
        public async Task<ActionResult> UpdateCountryDetails([FromBody] Country country)
        {
            await Task.Run(() => _employee.UpdateCountryDetails(country)).ConfigureAwait(continueOnCapturedContext: false);
            return Ok();
        }
        [Route("[action]")]
        [HttpPut]
        public async Task<ActionResult> UpdateEmployeeDetails([FromBody] Employee employee)
        {
            await Task.Run(() => _employee.UpdateEmployeeDetails(employee)).ConfigureAwait(continueOnCapturedContext: false);
            return Ok();
        }
        [Route("[action]")]
        [HttpPut]
        public async Task<ActionResult> UpdateStateDetails([FromBody] State state)
        {
            await Task.Run(() => _employee.UpdateStateDetails(state)).ConfigureAwait(continueOnCapturedContext: false);
            return Ok();
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> GetCaching()
        {
            string message = string.Empty;
            var country = new Country
            {
                CountryId = 1,
                CountryName = "OM"
            };
            var jsonString = JsonConvert.SerializeObject(country);
            var cacheOptions = new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromSeconds(15)
            };


            _distributedCache.SetString("CachedString1", jsonString, cacheOptions);

            message = _distributedCache.GetString("CachedString1");
            return Ok(message);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> GetSession()
        {
            try
            {
                string message = string.Empty;
                var country = new Country
                {
                    CountryId = 1,
                    CountryName = "OM"
                };
                var jsonString = JsonConvert.SerializeObject(country);
                var context = HttpContext;
                var contextSession = HttpContext.Session;
                HttpContext.Session.SetString("sessionkey", jsonString);
                message = HttpContext.Session.GetString("sessionkey");
                return Ok(message);
            }
            catch (Exception exception)
            {
                return NotFound(exception);
            }
        }
    }
}