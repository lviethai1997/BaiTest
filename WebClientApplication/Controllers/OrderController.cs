using Microsoft.AspNetCore.Mvc;
using Services.Catalog.Orders;

namespace WebClientApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

       [Route("/orders.html",Name = "orders")]
        public async Task<IActionResult> Index()
        {
            string Username = HttpContext.Session.GetString("SessionUser");
            var ordersOfUser = await _orderService.GetOrderByUser(Username);
            return View(ordersOfUser);
        }

        [Route("orderdetail.{id}.html", Name = "orderdetail")]
        public async Task<IActionResult> OrderDetail(int id)
        {
            var orderdetail = await _orderService.GetOrderDetail(id);
            return View(orderdetail);
        }

        [Route("/OrderCancel.{id}.html",Name = "OrderCancel")]
        public async Task<IActionResult> DestroyOrder(int id)
        {
            var destroy = await _orderService.DestroyOrder(id);
            return RedirectToAction("Index");
        }
    }
}
