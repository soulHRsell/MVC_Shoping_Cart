using Shoping_Card_DB_Connection.Models;

namespace Shoping_Card_DB_Connection.DataAccess
{
    public interface ISqlData
    {
        void CreateCategory(CategoryCreateModel category);
        void Createuser(UserModel user);
        void EditUserInfo(int Id, UserEditModel user);
        List<CategoryModel> GetAllCategories();
        List<ProductModel> GetProducts();
        List<UserModel> GetUserById(int Id);
        List<UserAuthoModel> GetUserByUsername(string username);
    }
}