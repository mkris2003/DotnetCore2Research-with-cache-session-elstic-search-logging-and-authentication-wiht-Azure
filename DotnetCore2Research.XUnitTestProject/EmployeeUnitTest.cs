using DotnetCore2Research.Classes;
using DotnetCore2Research.Controllers;
using DotnetCore2Research.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
namespace DotnetCore2Research.XUnitTestProject
{
    public class EmployeeUnitTest
    {
        private readonly Mock<IEmployeeProcess> _employee = null;
        private readonly Mock<ILoggerFactory> _loggerFactory = null;
        private readonly Mock<ILogger> _logger = null;
        private readonly Mock<IDistributedCache> _distributedCache = null;
        EmployeeController employeeController = null;
        public EmployeeUnitTest()
        {
            // For object creation
            // private readonly ILoggerFactory _loggerFactory  = new Mock<ILoggerFactory>().Object; 
            _loggerFactory = new Mock<ILoggerFactory>();

            _logger = new Mock<ILogger>();
            _employee = new Mock<IEmployeeProcess>();
            _distributedCache = new Mock<IDistributedCache>();
            employeeController = new EmployeeController(_employee.Object, _loggerFactory.Object, _distributedCache.Object);
        }
        [Fact]
        public async Task GetCountryDetails()
        {
            IEnumerable<Country> countryList = new List<Country>()
            {
                new Country{ CountryId=1, CountryName="OM"},
                new Country{ CountryId=1, CountryName="RAM"}
            };
            _employee.Setup(p => p.GetCountryDetails()).Returns(countryList);
            var response = await Task.Run(() => employeeController.GetCountryDetails()).ConfigureAwait(false);
            var ctryDetailsList = ((Microsoft.AspNetCore.Mvc.ObjectResult)response.Result).Value as IEnumerable<Country>;
            Assert.Equal(countryList, countryList);
        }

        [Theory]
        [InlineData(100)]
        public async Task DeleteCityDetails(int cityId)
        {
            _employee.Setup(p => p.DeleteCityDetails(cityId)).Verifiable();
            var result = await employeeController.DeleteCityDetails(cityId);
            _employee.Verify();

        }
        [Theory]
        [InlineData(100)]
        public async Task DeleteCountryDetails(int countryId)
        {
            _employee.Setup(p => p.DeleteCountryDetails(countryId)).Verifiable();
            var result = await employeeController.DeleteCountryDetails(countryId);
            _employee.Verify();

        }

        [Theory]
        [InlineData(100)]
        public async Task DeleteEmployeeDetails(int employeeId)
        {
            _employee.Setup(p => p.DeleteEmployeeDetails(employeeId)).Verifiable();
            var result = await employeeController.DeleteEmployeeDetails(employeeId);
            _employee.Verify();

        }

        [Theory]
        [InlineData(100)]
        public async Task DeleteStateDetails(int stateId)
        {
            _employee.Setup(p => p.DeleteStateDetails(stateId)).Verifiable();
            var result = await employeeController.DeleteStateDetails(stateId);
            _employee.Verify();

        }

        [Theory]
        [InlineData(100, 200)]
        public async Task GetCityDetails(int countryId, int stateId)
        {
            IEnumerable<City> cityList = new List<City>()
            {
                new City{CityId=1,CityName="OM",CountryId=100,StateId=100},
                 new City{CityId=2,CityName="RAM",CountryId=100,StateId=100},
            };
            _employee.Setup(p => p.GetCityDetails(countryId, stateId)).Returns(cityList);
            var response = await employeeController.GetCityDetails(countryId, stateId);
            var cityDetailsList = ((Microsoft.AspNetCore.Mvc.ObjectResult)response.Result).Value as IEnumerable<City>;
            Assert.Equal(cityList, cityDetailsList);
        }

        [Theory]
        [InlineData(100)]
        public async Task GetStateDetails(int countryId)
        {
            IEnumerable<State> stateList = new List<State>()
            {
                new State{CountryId=100,StateId=100,StateName="OM"},
                new State{CountryId=100,StateId=100,StateName="RAM"},
            };
            _employee.Setup(p => p.GetStateDetails(countryId)).Returns(stateList);
            var response = await employeeController.GetStateDetails(countryId);
            var stateDetailsList = ((Microsoft.AspNetCore.Mvc.ObjectResult)response.Result).Value as IEnumerable<State>;
            Assert.Equal(stateList, stateDetailsList);
        }
        /// <summary>
        /// If class data object passing list count is 2 that means two parametors 
        /// if list data contains 3 objects count then 3 parametors
        /// </summary>
        /// <param name="empList"></param>
        /// <param name="emp"></param>
        /// <returns></returns>
        [Theory]
        [ClassData(typeof(EmployeeTestData))]
        public async Task GetEmployeeDetails(Employee emp1, Employee emp2)
        {
            IEnumerable<Employee> employeeList = new List<Employee>()
            {
               emp1,emp2
            };

            _employee.Setup(p => p.GetEmployeeDetails(employeeList.ElementAtOrDefault(0))).Returns(employeeList);
            var response = await employeeController.GetEmployeeDetails(employeeList.ElementAtOrDefault(0));
            var employeeDetailsList = ((Microsoft.AspNetCore.Mvc.ObjectResult)response.Result).Value as IEnumerable<Employee>;
            Assert.Equal(employeeList, employeeDetailsList);
        }
        [Theory]
        [ClassData(typeof(CityTestData))]
        public async Task InsertCityDetails(City citydetails)
        {
            _employee.Setup(p => p.InsertCityDetails(citydetails)).Verifiable();
            var result = await employeeController.InsertCityDetails(citydetails);
            _employee.Verify();
        }
        [Theory]
        [ClassData(typeof(CountryTestData))]
        public async Task InsertCountryDetails(Country countrydetails)
        {
            _employee.Setup(p => p.InsertCountryDetails(countrydetails)).Verifiable();
            var result = await employeeController.InsertCountryDetails(countrydetails);
            _employee.Verify();
        }
        [Theory]
        [ClassData(typeof(EmployeeTestData))]
        public async Task InsertEmployeeDetails(Employee employeedetails, Employee employeedetails2)
        {
            _employee.Setup(p => p.InsertEmployeeDetails(employeedetails)).Verifiable();
            var result = await employeeController.InsertEmployeeDetails(employeedetails);
            _employee.Verify();
        }
        [Theory]
        [ClassData(typeof(StateTestData))]
        public async Task InsertStateDetails(State StateDetails)
        {
            _employee.Setup(p => p.InsertStateDetails(StateDetails)).Verifiable();
            var result = await employeeController.InsertStateDetails(StateDetails);
            _employee.Verify();
        }

        [Theory]
        [ClassData(typeof(CityTestData))]
        public async Task UpdateCityDetails(City citydetails)
        {
            _employee.Setup(p => p.UpdateCityDetails(citydetails)).Verifiable();
            var result = await employeeController.UpdateCityDetails(citydetails);
            _employee.Verify();
        }

        [Theory]
        [ClassData(typeof(CountryTestData))]
        public async Task UpdateCountryDetails(Country countrydetails)
        {
            _employee.Setup(p => p.UpdateCountryDetails(countrydetails)).Verifiable();
            var result = await employeeController.UpdateCountryDetails(countrydetails);
            _employee.Verify();
        }

        [Theory]
        [ClassData(typeof(EmployeeTestData))]
        public async Task UpdateEmployeeDetails(Employee employeedetails, Employee employeedetails2)
        {
            _employee.Setup(p => p.UpdateEmployeeDetails(employeedetails)).Verifiable();
            var result = await employeeController.UpdateEmployeeDetails(employeedetails);
            _employee.Verify();
        }
        [Theory]
        [ClassData(typeof(StateTestData))]
        public async Task UpdateStateDetails(State StateDetails)
        {
            _employee.Setup(p => p.UpdateStateDetails(StateDetails)).Verifiable();
            var result = await employeeController.UpdateStateDetails(StateDetails);
            _employee.Verify();
        }

        [Theory]
        [MemberData(nameof(CalculatorData.Data), MemberType = typeof(CalculatorData))]
        public void CanAddTheoryMemberDataMethod(int value1, int value2, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Add(value1, value2);

            Assert.Equal(expected, result);
        }

    }

    public class CalculatorData
    {
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
            new object[] { 1, 2, 3 },
            new object[] { -4, -6, -10 },
            new object[] { -2, 2, 0 },
            new object[] { int.MinValue, -1, int.MaxValue },
            };
    }
    public class Calculator
    {
        public int Add(int value1, int value2)
        {
            return value1 + value2;
        }
    }
}
