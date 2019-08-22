using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore2Research.Azure.Classes
{
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; } = string.Empty;
        public int CountryId { get; set; }
    }
}
