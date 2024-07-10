using Microsoft.Extensions.Hosting;
using MvcCadastroContatos.Enum;

namespace MvcCadastroContatos.Models;

public class RedefinirSenhaModel
{
    public string Login { get; set; }
    public string Email { get; set; }
}
