using Microsoft.AspNetCore.Mvc;
using framedart_project_frontend.Service.Interfaces;

namespace framedart_project_frontend.Controllers {

    public class OrderController : Controller {

        private readonly ISearchService _searchService;

        public OrderController (ISearchService searchService) {
            _searchService = searchService;
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

    }
}
