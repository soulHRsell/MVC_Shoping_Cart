using Shoping_Card_DB_Connection.Databases;
using Shoping_Card_DB_Connection.Models;

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

        public List<UserModel> GetUserById(int Id)
        {
            return _db.LoadData<UserModel, dynamic>("SP_GetUserById",
                                new { Id },
                                connectionStringName,
                                true);
        }

        public List<UserAuthoModel> GetUserByUsername(string username)
        {
            return _db.LoadData<UserAuthoModel, dynamic>("dbo.SP_GetUserByUsername",
                                                         new { username },
                                                         connectionStringName,
                                                         true);
        }

        public List<ProductModel> GetProducts()
        {
            return _db.LoadData<ProductModel, dynamic>("select * from ViewAllProducts",
                                                        new { },
                                                        connectionStringName,
                                                        false);
        }

        public void Createuser(UserModel user)
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

        public void EditUserInfo(int Id, UserEditModel user)
        {
            _db.SaveData<dynamic>("SP_EditUserInfo",
                                  new { Id, user.Username, user.EmailAddress, user.FirstName, user.LastName, user.Country, user.State, user.City, user.ZipCode, user.CardNumber },
                                  connectionStringName,
                                  true);
        }
    }
}
