using Microsoft.AspNetCore.Mvc;

namespace framedart_project_frontend.Controllers {

    [Route("OS")]
    public class OrdemServicoController : Controller {

        [Route("Adicionar")]
        public IActionResult AdicionarOS () {
            return View();
        }

    }
}
