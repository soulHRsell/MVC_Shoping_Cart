using Shoping_Card_DB_Connection.Models;

namespace Shoping_Card_DB_Connection.DataAccess
{
    public interface ISqlData
    {
        void CreateCategory(string name);
        void CreateProduct(ProductModel product);
        void Createuser(UserModel user);
        void DeleteCategory(int Id);
        void EditCategory(CategoryModel category);
        void EditProduct(ProductModel product);
        void EditUserInfo(int Id, UserModel user);
        List<CategoryModel> GetAllCategories();
        List<CategoryModel> GetCategoryById(int Id);
        List<CategoryModel> GetCategoryByName(string name);
        List<ProductModel> GetProductById(int Id);
        List<ProductModel> GetProductByName(string name);
        List<ProductModel> GetProducts();
        List<UserModel> GetUserById(int Id);
        List<UserAuthoModel> GetUserByUsername(string username);
    }
}