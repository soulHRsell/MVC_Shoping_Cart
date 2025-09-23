using Shoping_Card_DB_Connection.Databases;
using Shoping_Card_DB_Connection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping_Card_DB_Connection.DataAccess
{
    public class SqlData : ISqlData
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }

        public List<ProductsModel> GetProducts()
        {
            return _db.LoadData<ProductsModel, dynamic>("dbo.Get_AllProducts",
                                                        new { },
                                                        connectionStringName,
                                                        true);
        }
    }
}
