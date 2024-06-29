using Microsoft.AspNetCore.Mvc;
using MvcCadastroContatos.Helper;
using MvcCadastroContatos.Models;
using MvcCadastroContatos.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MvcCadastroContatos.Controllers;

public class LoginController : Controller
{
    private readonly IUsuariosRepositiorio _usuarioRepositorio;
    private readonly ISessao _sessao;
    public LoginController(IUsuariosRepositiorio usuarioRepositorio, ISessao sessao)
    {
        _usuarioRepositorio = usuarioRepositorio;
        _sessao = sessao;
    }
    public IActionResult Index()
    {
        //Se o usuário já está logado, manda para a home
        if(_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index","Home");
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginModel usuario)
    {
        var usuarioExistente = _usuarioRepositorio.ValidaUser(usuario.Login,usuario.Senha);
        
        if (usuarioExistente!=null)
        {
            TempData["MensagemSucesso"] = $"Login realizada com sucesso !!";
            _sessao.CriarSessaoDoUsuario(usuarioExistente);
            return RedirectToAction("Index", "Home", usuarioExistente);
        }
        TempData["MensagemErro"] = $"Usuário não credenciado, Realize o cadastro no botão Cadastrar !!";
        return RedirectToAction("Index", "Login");
    }

    public IActionResult Sair()
    {
        _sessao.RemoverSessaoUsuario();
        return RedirectToAction("Index", "Login");
    }
    
}
