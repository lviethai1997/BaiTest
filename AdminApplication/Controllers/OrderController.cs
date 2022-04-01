using Microsoft.AspNetCore.Mvc;
using Services.Catalog.Orders;

namespace AdminApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var listOrders = await _orderService.GetAll();
            return View(listOrders);
        }

        public async Task<IActionResult> OrderDetail(int id)
        {
            var orderDetail = await _orderService.GetOrderDetail(id);
            return View(orderDetail);
        }


        public async Task<IActionResult> TakeOrder(int id)
        {
            await _orderService.TakeOrder(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CompleteOrder(int id)
        {
            await _orderService.CompleteOrder(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DestroyOrder(int id)
        {
            await _orderService.DestroyOrder(id);
            return RedirectToAction("Index");
        }
    }
}
