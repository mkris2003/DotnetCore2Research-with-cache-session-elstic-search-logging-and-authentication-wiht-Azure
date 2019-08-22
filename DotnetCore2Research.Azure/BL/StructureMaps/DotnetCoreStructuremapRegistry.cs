using DotnetCore2Research.Azure.Classes;
using DotnetCore2Research.Azure.DL;

using StructureMap;
using StructureMap.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore2Research.Azure.BL.StructureMaps
{
    public class DotnetCoreStructuremapRegistry : Registry
    {
        public DotnetCoreStructuremapRegistry()
        {

         

            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();

            });
        }
    }
}
