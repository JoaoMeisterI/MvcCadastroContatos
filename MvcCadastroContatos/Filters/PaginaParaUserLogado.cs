using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MvcCadastroContatos.Models;
using Newtonsoft.Json;

namespace MvcCadastroContatos.Filters;

public class PaginaUserLogado : ActionFilterAttribute
{
    //Antes de fazer qualquer execução ele cai nessa OnActionExecuting
    
    //Para evitar que qualquer pessoa possa mexer diretamente nas rotas 
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        //Forma de pegar a sessão do user pela nossa chave
        string sessaoUsuario= context.HttpContext.Session.GetString("sessaoUserLogado");

        //Caso for vazia retorna para a controller login action Index
        if(string.IsNullOrEmpty(sessaoUsuario))
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary {{"controller","Login"},{"action","Index2"}});
        }
        else
        {
            UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
            
            if(usuario==null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary {{"controller","Login"},{"action","Index"}});
            }
        }
        base.OnActionExecuting(context);

    }
}