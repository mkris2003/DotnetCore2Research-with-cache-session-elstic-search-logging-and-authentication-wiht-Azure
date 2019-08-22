using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DotnetCore2Research.Azure.DL.EmployeeConnection;
namespace DotnetCore2Research.Azure.DL
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfigurationRoot _configuration;
        private readonly static string _connectionStringName = "EmployeeConnection";

        public SqlConnectionFactory(IConfigurationRoot configuration)
        {
            _configuration = configuration;
            EmployeeConnectionstring = _configuration.GetConnectionString(_connectionStringName);

        }
        public string ConnectionString()
        {          
            return EmployeeConnectionstring;
        }
    }
}
