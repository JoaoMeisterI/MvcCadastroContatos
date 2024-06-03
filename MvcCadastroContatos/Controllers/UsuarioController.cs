using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcCadastroContatos.Repositorio;

namespace MvcCadastroContatos.Controllers;

public class UsuarioController : Controller
{
    private readonly IUsuariosRepositiorio _usuarioRepositorio;
    public UsuarioController(IUsuariosRepositiorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }

    public IActionResult Criar() 
    {
        return View();
    }

    public IActionResult Editar()
    {
        return View();
    }

    public IActionResult Deletar()
    {
        return View();
    }

}
