using Data.EF;
using Data.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Catalog.Orders
{
    public class OrderService : IOrderService
    {
        private readonly ShopDbContext _context;

        public OrderService(ShopDbContext context)
        {
            _context = context;
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


            return  new Order();

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
