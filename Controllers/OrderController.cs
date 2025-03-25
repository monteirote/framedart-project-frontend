using Microsoft.AspNetCore.Mvc;
using framedart_project_frontend.Service.Interfaces;
using framedart_project_frontend.Models.Order;

namespace framedart_project_frontend.Controllers {

    public class OrderController : Controller {

        private readonly ISearchService _searchService;
        private readonly IOrderService _orderService;

        public OrderController (ISearchService searchService, IOrderService orderService) {
            _searchService = searchService;
            _orderService = orderService;
        }

        [HttpGet("os/adicionar")]
        public IActionResult AdicionarOS () {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> SearchCustomer (string text) {
            var results = await _searchService.SearchCustomer(text);
            return Json(results);
        }

        [HttpGet]
        public async Task<JsonResult> SearchMaterial (string text, string type) {
            var results = await _searchService.SearchMaterial(text, type);
            return Json(results);
        }

        public async Task<JsonResult> CreateOrder (OrderRequestModel order) {
            var results = await _orderService.SubmitOrder(order);
            return Json(results);
        }

    }
}
