using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcCadastroContatos.Models;
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

    public IActionResult Editar(int Id)
    {
        UsuarioModel usuario = _usuarioRepositorio.BuscarUserId(Id);
        return View(usuario);
    }

    public IActionResult Deletar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Criar(UsuarioModel usuario)
    {
        try
        {
            
           _usuarioRepositorio.Adicionar(usuario);
           TempData["MensagemSucesso"] = "Usuário Incluido com Sucesso!!";
            
            return View(usuario);
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Não foi Possível Adicionar o Contato, ERRO: {erro}!";
            return RedirectToAction("Contato/Index");
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
                TempData["MensagemSucesso"] = "Usuario Alterado com Sucesso!!";
                return RedirectToAction("Index");
            }
            //Caso o método tivesse outro nome teria que fazer isso
            return View(usuario);
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Não foi Possível Alterar o Usuario, ERRO: {erro.Message} !!";
            return RedirectToAction("Index");
        }
    }


}
