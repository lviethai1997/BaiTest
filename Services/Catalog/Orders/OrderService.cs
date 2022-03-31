using Data.EF;
using Data.Entites;
using Microsoft.EntityFrameworkCore;
using ViewModels.Catalog.Checkout;

namespace Services.Catalog.Orders
{
    public class OrderService : IOrderService
    {
        private readonly ShopDbContext _context;

        public OrderService(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ComfirmOrder(CheckOutRequest request)
        {
            var order = new Order()
            {
                CustomerAddress = request.user.Address,
                CustomerEmail = request.user.Email,
                CustomerMobile = request.user.Mobile,
                CustommerId = request.user.ID,
                CustomerName = request.user.FullName,
                CreateDate = DateTime.Now,
                Status = 0,
                CreatedBy = request.user.Username,
                CustomerMessage = "OK"
            };
            var addOrder =  _context.Orders.Add(order);
             _context.SaveChanges();

            var orderDetails = new List<OrderDetail>();
            foreach (var item in request.carts)
            {
                var detail = new OrderDetail();
                detail.OrderID = order.ID;
                detail.ProductID = item.product.ID;
                detail.Quantity = item.quantity;
                detail.Price = item.product.Price;
                orderDetails.Add(detail);
                var addOrderDetail =  _context.OrderDetails.Add(detail);
            }

             _context.SaveChanges();

            return true;
        }

        public Task<bool> CompleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DestroyOrder(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrderDetail(int id)
        {
            var orderDetail = from o in _context.Orders
                              join od in _context.OrderDetails on o.ID equals od.OrderID
                              join p in _context.Products on od.ProductID equals p.ID
                              join u in _context.User on o.CustommerId equals u.ID
                              where od.OrderID == id
                              select new { o, od, p, u };

            return new Order();
        }

        public async Task<List<Order>> getOrders()
        {
            var orders = await _context.Orders.Select(x => new Order()).ToListAsync();
            return orders;
        }

        public Task<bool> TakeOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}