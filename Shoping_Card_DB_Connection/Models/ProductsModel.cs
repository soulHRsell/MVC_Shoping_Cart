using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping_Card_DB_Connection.Models
{
    public class ProductsModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string Info { get; set; }
        [Required]
        public int CategoryId { get; set; } 
    }
}
