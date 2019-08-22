using DotnetCore2Research.Classes;
using DotnetCore2Research.DL;

using StructureMap;
using StructureMap.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore2Research.BL.StructureMaps
{
    public class DotnetCoreStructuremapRegistry : Registry
    {
        public DotnetCoreStructuremapRegistry()
        {

            //For<GlobalConnectionClass>().LifecycleIs(Lifecycles.Container)
            //                   .Use<GlobalConnectionClass>();

            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();

            });
        }
    }
}
