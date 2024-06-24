using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcCadastroContatos.Models;
using MvcCadastroContatos.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MvcCadastroContatos.Controllers;

public class UsuarioController : Controller
{
    private readonly IUsuariosRepositiorio _usuarioRepositorio;
    public UsuarioController(IUsuariosRepositiorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }

    public IActionResult Login()
    {
        return View();
    }
    public IActionResult Criar() 
    {
        return View();
    }

    public IActionResult Editar(int Id)
    {
        try
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarUserId(Id);
            return View(usuario);
        }
        catch
        {
            TempData["MensagemErro"] = $"Usuário não existe !!";
            return RedirectToAction("Index", "Contato");
        }
        
    }

    public IActionResult Deletar(int id)
    {
        try
        {
            _usuarioRepositorio.Apagar(id);
            TempData["MensagemSucesso"] = "Usuário Removida com Sucesso!!";
            return RedirectToAction("Index", "Contato");
        }
        catch(Exception erro)
        {
            TempData["MensagemErro"] = $"Não foi Possível Remover o Usuário, ERRO: {erro.Message} !!";
            return RedirectToAction("Index", "Contato");
        }
    }

    [HttpPost]
    public IActionResult Criar(UsuarioModel usuario)
    {
        try
        {
            
           _usuarioRepositorio.Adicionar(usuario);
           TempData["MensagemSucesso"] = "Usuário Incluido com Sucesso!!";

            return RedirectToAction("Login");
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
    [HttpPost]
    public IActionResult CriarContato(ContatoModel contato,int id)
    {
        try
        {
           
            UsuarioModel user = _usuarioRepositorio.BuscarUserId(id);
            _usuarioRepositorio.Atualizar(user,contato);
            TempData["MensagemSucesso"] = "Contato Adicionado com Sucesso!!";
            return RedirectToAction("Index", "Contato", user);
            //Caso o método tivesse outro nome teria que fazer isso
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Não foi Possível Adicionar o contato, ERRO: {erro.Message} !!";
            return RedirectToAction("Index", "Contato");
        }
       
    }
}
