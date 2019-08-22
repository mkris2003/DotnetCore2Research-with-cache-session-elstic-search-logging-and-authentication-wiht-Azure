using System.Data.SqlClient;

namespace DotnetCore2Research.DL
{
    public static class DatabaseExtesions
    {
        public static SqlParameter WithValue(this SqlParameter parameter, object value)
        {
            parameter.Value = value;
            return parameter;
        }
    }
}
