using Microsoft.AspNetCore.Mvc;
using MvcCadastroContatos.Helper;
using MvcCadastroContatos.Models;
using MvcCadastroContatos.Repositorio;

namespace MvcCadastroContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuariosRepositiorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        public UsuarioController(IUsuariosRepositiorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscaTodos();
            return View(usuarios);
        }

        public IActionResult Criar2()
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
        public IActionResult Criar2(UsuarioModel usuario)
        {
            try{
                _usuarioRepositorio.Adicionar(usuario);
                TempData["MensagemSucesso"] = "Usuário Incluído com Sucesso!!";

                if(_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index","Usuario");

                return RedirectToAction("Index2","Login");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi Possível Adicionar o Contato, ERRO: {erro.Message}!";
                return RedirectToAction("Index","Usuario");
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
