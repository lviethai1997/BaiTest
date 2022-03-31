using Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Checkout;

namespace Services.Catalog.Orders
{
    public interface IOrderService
    {
        public Task<List<Order>> getOrders();

        public Task<Order> GetOrderDetail(int id);

        public Task<bool> DestroyOrder(int id);
        public Task<bool> TakeOrder(int id);
        public Task<bool> CompleteOrder(int id);

        public Task<bool> ComfirmOrder(CheckOutRequest request);
    }
}
