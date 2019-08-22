using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore2Research.Azure.DL
{
    public interface IDbConnectionFactory
    {
        string ConnectionString();
    }
}
