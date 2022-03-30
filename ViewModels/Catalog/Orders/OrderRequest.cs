namespace ViewModels.Catalog.Orders
{
    public class OrderRequest
    {
        public int ID { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerMobile { get; set; }

        public string CustomerMessage { get; set; }

        public string CreatedBy { get; set; }

        public int Status { get; set; }

        public int CustommerId { get; set; }

        public DateTime CreateDate { get; set; }
    }
}