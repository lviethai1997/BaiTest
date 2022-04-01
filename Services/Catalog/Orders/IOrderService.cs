using Data.Entites;
using ViewModels.Catalog.Checkout;
using ViewModels.Catalog.OrderDetails;
using ViewModels.Catalog.Orders;

namespace Services.Catalog.Orders
{
    public interface IOrderService
    {
        public Task<List<Order>> getOrders();

        public Task<bool> DestroyOrder(int id);

        public Task<bool> TakeOrder(int id);

        public Task<bool> CompleteOrder(int id);

        public Task<bool> ComfirmOrder(CheckOutRequest request);

        public Task<List<OrderRequest>> GetOrderByUser(string userName);

        public Task<OrderDetailRequest> GetOrderDetail(int orderId);

        public Task<List<OrderRequest>> GetAll();
    }
}