using Microsoft.AspNetCore.Mvc;

namespace GerenciadorCondominios.UI.Controllers;

public class UsuariosController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Registro()
    {
        return View();
    }
}
