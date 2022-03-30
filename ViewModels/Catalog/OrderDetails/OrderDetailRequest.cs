namespace ViewModels.Catalog.OrderDetails
{
    public class OrderDetailRequest
    {
        public int Username { get; set; }

        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string ProductName { get; set; }
        public string ImagePath { get; set; }
        public decimal PriceProduct { get; set; }
        public int QuantityCart { get; set; }
        public decimal PriceCart { get; set; }
    }
}