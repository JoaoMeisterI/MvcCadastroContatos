using Microsoft.AspNetCore.Mvc;
using MvcCadastroContatos.Models;
using MvcCadastroContatos.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MvcCadastroContatos.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}