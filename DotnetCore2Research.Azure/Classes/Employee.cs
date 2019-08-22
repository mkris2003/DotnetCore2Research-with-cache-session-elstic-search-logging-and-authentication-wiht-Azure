using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore2Research.Azure.Classes
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string EmpFirstName { get; set; } = string.Empty;
        public string EmpLastName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateTime BeginDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MinValue;
        public DateTime DateofJoined { get; set; } = DateTime.MinValue;
        public int PageNo { get; set; } 
        public int PageSize { get; set; }
        public string SortColumn { get; set; } = string.Empty;
        public string SortOrder { get; set; } = string.Empty;

    }
}
