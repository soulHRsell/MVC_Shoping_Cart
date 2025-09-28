using Shoping_Card_DB_Connection.Models;

namespace Shoping_Card_DB_Connection.DataAccess
{
    public interface ISqlData
    {
        void CreateCategory(CategoryCreateModel category);
        void Createuser(RegisterViewModel user);
        List<ProductsViewModel> GetProducts();
        List<UserAuthoModel> GetUserByUsername(string username);
    }
}