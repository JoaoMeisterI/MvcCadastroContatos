using Microsoft.Extensions.Hosting;
using MvcCadastroContatos.Enum;

namespace MvcCadastroContatos.Models;

public class LoginModel
{
    public string Login { get; set; }
    public string Senha { get; set; }
}
