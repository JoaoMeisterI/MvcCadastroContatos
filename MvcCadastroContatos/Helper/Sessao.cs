using Newtonsoft.Json;
using MvcCadastroContatos.Models;

namespace MvcCadastroContatos.Helper;

public class Sessao : ISessao
{
    private readonly IHttpContextAccessor _httpContext;
    
    public Sessao(IHttpContextAccessor httpContext)
    {
        _httpContext=httpContext;
    }

    public void CriarSessaoDoUsuario(UsuarioModel usuario)
    {
        string valor = JsonConvert.SerializeObject(usuario);
        _httpContext.HttpContext.Session.SetString("sessaoUserLogado", valor);
    }

    public void RemoverSessaoUsuario()
    {
        _httpContext.HttpContext.Session.Remove("sessaoUserLogado");
    }

    public UsuarioModel BuscarSessaoUsuario()
    {
        string sessaoUsuario= _httpContext.HttpContext.Session.GetString("sessaoUserLogado");

        if (string.IsNullOrEmpty(sessaoUsuario)) return null;

        return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
    }
}