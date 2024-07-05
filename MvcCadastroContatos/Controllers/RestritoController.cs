using Microsoft.AspNetCore.Mvc;
using MvcCadastroContatos.Filters;
using MvcCadastroContatos.Models;
using MvcCadastroContatos.Repositorio;

namespace MvcCadastroContatos.Controllers;
public class RestritoController : Controller
{
    [PaginaUserLogado]
    public IActionResult Index()
    {
        return View();
    }
}