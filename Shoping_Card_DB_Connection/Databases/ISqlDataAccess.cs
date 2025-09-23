
namespace Shoping_Card_DB_Connection.Databases
{
    public interface ISqlDataAccess
    {
        List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionStringName, bool isStoredProcidure);
        void SaveData<T>(string sqlstatement, T parameters, string connectionStringName, bool isStoredProcidure);
    }
}