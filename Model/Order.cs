namespace GenericProject.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        //foreign key
        public int ProductId { get; set; }

        //Navigation property
        public Product Product { get; set; }
    }
}
