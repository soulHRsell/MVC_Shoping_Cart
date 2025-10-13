namespace MVC_Shoping_Card.Models
{
    public class ProductCreateViewModel
    {
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();    
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Info { get; set; }
        public int Price { get; set; }
        public int Category { get; set; }
    }
}
