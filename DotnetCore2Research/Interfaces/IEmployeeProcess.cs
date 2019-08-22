using DotnetCore2Research.Classes;
using System.Collections.Generic;

namespace DotnetCore2Research.Interfaces
{
    public interface IEmployeeProcess
    {
        IEnumerable<Country> GetCountryDetails();
        void InsertCountryDetails(Country country);
        void UpdateCountryDetails(Country country);
        void DeleteCountryDetails(int countryId);
        IEnumerable<State> GetStateDetails(int countryId);
        void InsertStateDetails(State state);
        void UpdateStateDetails(State state);
        void DeleteStateDetails(int stateId);
        IEnumerable<City> GetCityDetails(int countryId, int stateId);
        void InsertCityDetails(City city);
        void UpdateCityDetails(City city);
        void DeleteCityDetails(int cityId);
        IEnumerable<Employee> GetEmployeeDetails(Employee employee);
        void InsertEmployeeDetails(Employee employee);
        void UpdateEmployeeDetails(Employee employee);
        void DeleteEmployeeDetails(int employeeId);

    }
}
