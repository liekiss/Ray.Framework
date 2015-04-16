using System;
using System.Data.SqlClient;
using System.Data;

namespace Repositories.DapperRepositories
{
    public class DpDbConnection
    {
        public static IDbConnection GetDbConnection()
        {
            IDbConnection con = new SqlConnection(Infrastructure.ParameterHelp.DbConnectionStr);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
    }
}
