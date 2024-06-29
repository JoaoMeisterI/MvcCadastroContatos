using Microsoft.AspNetCore.Mvc;
using MvcCadastroContatos.Models;
using MvcCadastroContatos.Repositorio;

namespace MvcCadastroContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuariosRepositiorio _usuarioRepositorio;
        public UsuarioController(IUsuariosRepositiorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscaTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            try
            {
                UsuarioModel usuario = _usuarioRepositorio.BuscarUserId(id);
                return View(usuario);
            }
            catch
            {
                TempData["MensagemErro"] = "Usuário não existe !!";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Deletar(int id)
        {
            try
            {
                _usuarioRepositorio.Apagar(id);
                TempData["MensagemSucesso"] = "Usuário Removido com Sucesso!!";
                return RedirectToAction("Index","Usuario");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi Possível Remover o Usuário, ERRO: {erro.Message} !!";
                return RedirectToAction("Index","Usuario");
            }
            
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try{
            
            
                _usuarioRepositorio.Adicionar(usuario);
                TempData["MensagemSucesso"] = "Usuário Incluído com Sucesso!!";
                return RedirectToAction("Index","Usuario");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi Possível Adicionar o Contato, ERRO: {erro.Message}!";
                return RedirectToAction("Index","Usuario");
            }
        }

        public IActionResult CriarNovoUser(UsuarioModel usuario)
        {
            try{
            
            
                _usuarioRepositorio.Adicionar(usuario);
                TempData["MensagemSucesso"] = "Usuário Incluído com Sucesso!!";
                return RedirectToAction("Index","Login");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi Possível Adicionar o Contato, ERRO: {erro.Message}!";
                return RedirectToAction("Index","Login");
            }
        }


        [HttpPost]
        public IActionResult Editar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário Alterado com Sucesso!!";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi Possível Alterar o Usuário, ERRO: {erro.Message} !!";
                return RedirectToAction("Index");
            }
        }
    }
}
