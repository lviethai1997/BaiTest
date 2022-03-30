namespace ViewModels.Catalog.OrderDetails
{
    public class OrderDetailRequest
    {
        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}