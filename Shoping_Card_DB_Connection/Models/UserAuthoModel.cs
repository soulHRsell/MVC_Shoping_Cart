using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping_Card_DB_Connection.Models
{
    public class UserAuthoModel
    {
        public int Id { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }  
    }
}
