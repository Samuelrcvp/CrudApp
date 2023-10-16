using CrudApp.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CrudApp.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
