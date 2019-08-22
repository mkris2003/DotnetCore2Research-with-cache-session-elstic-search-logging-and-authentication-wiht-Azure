using DotnetCore2Research.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotnetCore2Research.IntegrationTests
{
    public class EmployeeTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return GetEmployeeList().ToArray();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        private IEnumerable<Employee> GetEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    DateofJoined=DateTime.Now.AddDays(-30),
                    City="1",
                    State="1",
                    BeginDate=DateTime.Now.AddDays(-30),
                    Country="1",
                    EmpFirstName="OM",
                    EmpLastName="Vigneswara",
                    EmpNo=100,
                    EndDate=DateTime.Now,
                    PageNo=1,
                    PageSize=10,
                    SortColumn="EmpNo",
                    SortOrder="ASC"
                },
                new Employee
                {
                    DateofJoined=DateTime.Now.AddDays(-30),
                    City="1",
                    State="2",
                    BeginDate=DateTime.Now.AddDays(-30),
                    Country="2",
                    EmpFirstName="OM",
                    EmpLastName="OM",
                    EmpNo=200,
                    EndDate=DateTime.Now,
                    PageNo=1,
                    PageSize=10,
                    SortColumn="EmpNo",
                    SortOrder="ASC"
                },
                
            };
        }

       
    }
}
