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

        DateTime utcNow = DateTime.UtcNow;
        usuario.DataCadastro = utcNow;
        usuario.DataAtualizacao = new DateTime(2001, 1, 1);
        


        _bancoContext.Usuarios.Add(usuario);
        _bancoContext.SaveChanges();
        return usuario;
    }

    public UsuarioModel Atualizar(UsuarioModel usuario)
    {
        UsuarioModel usuarioAtualizado = BuscarUserId(usuario.Id);

        if (usuarioAtualizado==null) throw new System.Exception("Não foi possível realizar a atualização do usuário");

        usuarioAtualizado.Nome = usuario.Nome;
        usuarioAtualizado.Senha = usuario.Senha;
        usuarioAtualizado.Login = usuario.Login;
        usuarioAtualizado.Perfil = usuario.Perfil;
        usuarioAtualizado.DataAtualizacao = DateTime.UtcNow;

        _bancoContext.Update(usuarioAtualizado);
        _bancoContext.SaveChanges();
         return(usuario);

    }
    public UsuarioModel BuscarUserId(int id)
    {
        return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
    }
}
