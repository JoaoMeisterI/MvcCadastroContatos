using MvcCadastroContatos.Data;
using MvcCadastroContatos.Models;

namespace MvcCadastroContatos.Repositorio;


public class UsuarioRepositorio : IUsuariosRepositiorio
{
    private readonly BancoContext _bancoContext;
    public UsuarioRepositorio(BancoContext bancoContext)
    {
        _bancoContext = bancoContext;
    }
    public UsuarioModel Adicionar(UsuarioModel usuario)
    {
        if(usuario == null) throw new System.Exception("Contato não pode ser vazio");

        _bancoContext.Usuarios.Add(usuario);
        _bancoContext.SaveChanges();
        return usuario;
    }

}
