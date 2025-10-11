using System.ComponentModel.DataAnnotations;

namespace MVC_Shoping_Card.Models
{
    public class UserViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required, EmailAddress]
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int CardNumber { get; set; }
    }
}
