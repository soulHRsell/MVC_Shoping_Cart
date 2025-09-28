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

        public List<UserAuthoModel> GetUserByUsername(string username)
        {
            return _db.LoadData<UserAuthoModel, dynamic>("dbo.SP_GetUserByUsername",
                                                         new { username },
                                                         connectionStringName,
                                                         true);
        }

        public List<ProductsModel> GetProducts()
        {
            return _db.LoadData<ProductsModel, dynamic>("select * from ViewAllProducts",
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

        public void CreateCategory(CategoryCreateModel category)
        {
            _db.SaveData<dynamic>("SP_CreateNewCategory",
                                  new { category.AdminId, category.Name },
                                  connectionStringName,
                                  true);
        }
    }
}
