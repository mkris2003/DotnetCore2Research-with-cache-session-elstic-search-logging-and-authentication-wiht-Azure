using DotnetCore2Research.Classes;
using DotnetCore2Research.Interfaces;
using System.Collections.Generic;
using System.Linq;
using static DotnetCore2Research.DL.EmployeeDataAccess;
using static DotnetCore2Research.Common.Extensions;
namespace DotnetCore2Research.BL
{
    public class EmployeeProcess : IEmployeeProcess
    {
        public void DeleteCityDetails(int cityId)
        {
            DeleteCity(cityId);
        }

        public void DeleteCountryDetails(int countryId)
        {
            DeleteCountry(countryId);
        }

        public void DeleteEmployeeDetails(int employeeId)
        {
            DeleteEmployee(employeeId);
        }

        public void DeleteStateDetails(int stateId)
        {
            DeleteState(stateId);
        }

        public IEnumerable<City> GetCityDetails(int countryId, int stateId)
        {
            var dsCity = CityDetails(countryId, stateId);
            if (!dsCity.IsEmpty())
                return dsCity.Tables[0].DataTableToList<City>();
            return new List<City>();
        }

        public IEnumerable<Country> GetCountryDetails()
        {
            var dsCountry = CountryDetails();
            if (!dsCountry.IsEmpty())
                return dsCountry.Tables[0].DataTableToList<Country>();
            return new List<Country>();
        }

        public IEnumerable<Employee> GetEmployeeDetails(Employee employee)
        {
            var dsEmployee = EmployeeDetails(employee);
            if (!dsEmployee.IsEmpty())
                return dsEmployee.Tables[0].DataTableToList<Employee>();
            return new List<Employee>();
        }



        public IEnumerable<State> GetStateDetails(int countryId)
        {
            var dsStateDetails = StateDetails(countryId);
            if (!dsStateDetails.IsEmpty())
                return dsStateDetails.Tables[0].DataTableToList<State>();
            return new List<State>();
        }

        public void InsertCityDetails(City city)
        {
            InsertCity(city);
        }



        public void InsertCountryDetails(Country country)
        {
            InsertCountry(country);
        }



        public void InsertEmployeeDetails(Employee employee)
        {
            InsertEmployee(employee);
        }



        public void InsertStateDetails(State state)
        {
            InsertState(state);
        }


        public void UpdateCityDetails(City city)
        {
            UpdateCity(city);
        }



        public void UpdateCountryDetails(Country country)
        {
            UpdateCountry(country);
        }



        public void UpdateEmployeeDetails(Employee employee)
        {
            UpdateEmployee(employee);
        }



        public void UpdateStateDetails(State state)
        {
            UpdateState(state);
        }

    }
}
