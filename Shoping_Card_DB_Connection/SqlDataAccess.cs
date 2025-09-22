using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace Shoping_Card_DB_Connection
{
    internal class SqlDataAccess
    {
        public List<T> LoadData<T,U>(string sqlStatement, U parametrs, string connectionString)
        {
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(sqlStatement, parametrs).ToList();
                return rows;
            }
        }
        public void SaveData<T>(string sqlStatement, T parametrs, string connectionString)
        {
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(sqlStatement, parametrs);
            }
        }
    }
}
