using DotnetCore2Research.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore2Research.IntegrationTests
{
   public class CountryTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return GetCountryList().ToArray();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        private List<Country> GetCountryList()
        {
            return new List<Country>
             {
                 new Country{  CountryId=3, CountryName="Bharat"}
             };
        }

      
    }
}
