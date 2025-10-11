using System.ComponentModel.DataAnnotations;

namespace MVC_Shoping_Card.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }    
    }
}
