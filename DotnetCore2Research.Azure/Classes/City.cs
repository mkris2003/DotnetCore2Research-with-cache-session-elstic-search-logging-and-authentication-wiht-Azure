using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore2Research.Azure.Classes
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; } = string.Empty;
        public int StateId { get; set; }
        public int CountryId { get; set; }
    }
}
