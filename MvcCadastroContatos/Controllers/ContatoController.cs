using Microsoft.AspNetCore.Mvc;
using MvcCadastroContatos.Models;
using MvcCadastroContatos.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MvcCadastroContatos.Controllers;

public class ContatoController : Controller
{
    //Criando instancia do contatoRepositorio via construtor
    private readonly IContatosRepositorio _contatoRepositorio;
    public ContatoController(IContatosRepositorio contatoRepositorio)
    {
        _contatoRepositorio = contatoRepositorio;
    }
    public IActionResult Index()
    {
        List<ContatoModel> contatos = _contatoRepositorio.BuscarAllContatos();
        return View(contatos);
    }
    // Se não informa oq é ele vira um método get
    public IActionResult Criar2()
    {
        return View();
    }
    public IActionResult Editar(int id)
    {
        ContatoModel contato=_contatoRepositorio.BuscaContatoId(id);
        return View(contato);
    }

    public IActionResult ApagarConfirmacao(int id)
    {   
        ContatoModel contato= _contatoRepositorio.BuscaContatoId(id);
        return View(contato);
    }

    [HttpPost]
    public IActionResult Criar2(ContatoModel contato)
    {
        try
        {
            // Verifica se os dados correspondem com a model
            if (ModelState.IsValid)
            {
                //PARA RETORNAR VARIÁVEIS TEMPORÁRIAS USAMOS O RECURSO TempData["nomeDaVar"]
                _contatoRepositorio.Adicionar(contato);
                TempData["MensagemSucesso"] = "Contato Incluído com Sucesso!!";
                return RedirectToAction("Index");
            }
            return View(contato);
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Não foi Possível Incluir o Contato, ERRO: {erro.Message} !!";
            return RedirectToAction("Index"); 

        }
    }

    [HttpPost]
    public IActionResult Editar(ContatoModel contato)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _contatoRepositorio.Atualizar(contato);
                TempData["MensagemSucesso"] = "Contato Alterado com Sucesso!!";
                return RedirectToAction("Index");
            }
            //Caso o método tivesse outro nome teria que fazer isso
            return View(contato);
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Não foi Possível Alterar o Contato, ERRO: {erro.Message} !!";
            return RedirectToAction("Index");
        }
    }

    public IActionResult Apagar(int id)
    {
        try
        {
            if(ModelState.IsValid)
            {
               _contatoRepositorio.Apagar(id);
                TempData["MensagemSucesso"] = "Contato Removido com Sucesso!!";
                return RedirectToAction("Index");
            }
            return View();
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Não foi Possível Remover o Contato, ERRO: {erro.Message} !!";
            return RedirectToAction("Index");
        }
        
    }

}
