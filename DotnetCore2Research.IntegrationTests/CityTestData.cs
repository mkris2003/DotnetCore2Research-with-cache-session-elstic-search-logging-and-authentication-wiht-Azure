using DotnetCore2Research.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore2Research.IntegrationTests
{
   public  class CityTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return GetCityList().ToArray();
        }       

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private List<City> GetCityList()
        {
            return new List<City>
             {
                 new City{ CityId=2,CityName="Kondiakndukur", CountryId=1, StateId=1}
             };
        }

       
    }
}
