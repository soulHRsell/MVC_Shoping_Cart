namespace MVC_Shoping_Card.Models
{
    public class ProductCreateViewModel
    {
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();    
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Info { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
