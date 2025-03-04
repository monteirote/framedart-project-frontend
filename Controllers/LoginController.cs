using framedart_project_frontend.Service;
using framedart_project_frontend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace framedart_project_frontend.Controllers {

    public class LoginController : Controller {

        private readonly IAuthService _authService;

        public LoginController (IAuthService authService) {
            _authService = authService;
        }

        public ActionResult VerifyToken() {
            return RedirectToAction("Index");
        }

        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Login (string usuario, string senha) {

            var authenticated = await _authService.Authenticate(usuario, senha);

            if (!authenticated)
                return Json(new { success = false, message = "Usuário ou senha inválidos" });

            return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
        }

    }
}
