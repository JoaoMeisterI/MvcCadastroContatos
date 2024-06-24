using Microsoft.AspNetCore.Mvc;
using MvcCadastroContatos.Models;
using MvcCadastroContatos.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MvcCadastroContatos.Controllers;

public class LoginController : Controller
{
    private readonly IUsuariosRepositiorio _usuarioRepositorio;
    public LoginController(IUsuariosRepositiorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }
      public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginModel usuario)
    {
        var usuarioExistente = _usuarioRepositorio.ValidaUser(usuario.Login,usuario.Senha);
        
        if (usuarioExistente!=null)
        {
            TempData["MensagemSucesso"] = $"Login realizada com sucesso !!";
            return RedirectToAction("Index", "Contato", usuarioExistente);
        }
        TempData["MensagemErro"] = $"Usuário não credenciado, Realize o cadastro no botão Cadastrar !!";
        return View(usuario);
    }

    
}
