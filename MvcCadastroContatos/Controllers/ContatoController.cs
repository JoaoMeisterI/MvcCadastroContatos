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
        // tem que corrigir a questão de como colocar uma lista no db - migrations
    }
    // Se não informa oq é ele vira um método get
    public IActionResult Criar2(int id)
    {
        //variavel temporaria para usar em views
        TempData["idUsuario"] = id;
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
          
                //PARA RETORNAR VARIÁVEIS TEMPORÁRIAS USAMOS O RECURSO TempData["nomeDaVar"]
            _contatoRepositorio.Adicionar(contato);
            TempData["MensagemSucesso"] = "Contato Incluído com Sucesso!!";
            return RedirectToAction("Index","Contato");
            
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Não foi Possível Incluir o Contato, ERRO: {erro.Message} !!";
            return RedirectToAction("Index","Contato");

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
                 return RedirectToAction("Index","Contato");
            }
            //Caso o método tivesse outro nome teria que fazer isso
            return View(contato);
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Não foi Possível Alterar o Contato, ERRO: {erro.Message} !!";
             return RedirectToAction("Index","Contato");
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
                 return RedirectToAction("Index","Contato");
            }
            return View();
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Não foi Possível Remover o Contato, ERRO: {erro.Message} !!";
            return RedirectToAction("Index","Contato");
        }
        
    }

}
