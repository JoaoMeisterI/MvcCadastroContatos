using Microsoft.AspNetCore.Mvc;
using MvcCadastroContatos.Models;
using Newtonsoft.Json;

namespace MvcCadastroContatos.Controllers;

public class Menu : ViewComponent
{
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        string? sessaoUsuario = HttpContext.Session.GetString("sessaoUserLogado");
        
        if (string.IsNullOrEmpty(sessaoUsuario)) return View();

        UsuarioModel? usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

        return View(usuario);
    }
}