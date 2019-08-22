using DotnetCore2Research.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore2Research.XUnitTestProject
{
    public class StateTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return GetStateList().ToArray();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
              

        private List<State> GetStateList()
        {
            return new List<State>
             {
                 new State{  StateName="Andhrapradesh", CountryId=1, StateId=1}
             };
        }


    }
}
