using System.Runtime.CompilerServices;

namespace Shoping_Card_DB_Connection.Models
{
    public class ProductModel
    {    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Info { get; set; }
        public decimal Price { get; set; }  
        public int CategoryId { get; set; }
    }
}
