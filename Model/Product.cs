namespace GenericProject.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        //Navigation property
        public List<Order> Orders { get; set; }             
    }
}
