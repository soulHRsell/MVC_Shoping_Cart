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

        public List<ProductsViewModel> GetProducts()
        {
            return _db.LoadData<ProductsViewModel, dynamic>("select * from ViewAllProducts",
                                                        new { },
                                                        connectionStringName,
                                                        false);
        }

        public void Createuser(RegisterViewModel user)
        {
            _db.SaveData<dynamic>("dbo.SP_CreateUser",
                                  new { user.Username, user.Password, user.EmailAddress, user.FirstName, user.LastName, user.Country, user.State, user.City, user.ZipCode, user.CardNumber },
                                  connectionStringName,
                                  true);
        }
    }
}
