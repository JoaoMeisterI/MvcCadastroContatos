using Microsoft.Extensions.Hosting;
using MvcCadastroContatos.Enum;
using MvcCadastroContatos.Helper;

namespace MvcCadastroContatos.Models;

public class UsuarioModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public EnumUusuario Perfil { get; set; }
    public string Senha { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAtualizacao { get; set; }

    public string SetSenhaHash(String Senha)
    {
        //Para isso que serve o this, método de extensão isso
        Senha = Senha.GerarHash();

        return Senha;
    }
}
