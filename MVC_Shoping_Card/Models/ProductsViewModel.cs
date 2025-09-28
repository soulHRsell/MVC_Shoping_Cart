using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Shoping_Card.Models
{
    public class ProductsViewModel
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Info { get; set; }
    }
}
