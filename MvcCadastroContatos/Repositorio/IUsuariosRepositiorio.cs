using MvcCadastroContatos.Models;

namespace MvcCadastroContatos.Repositorio;

public interface IUsuariosRepositiorio
{
    UsuarioModel Adicionar(UsuarioModel usuario);
    bool Apagar(int id);
    UsuarioModel Atualizar(UsuarioModel usuario,ContatoModel contato=null);
    UsuarioModel BuscarUserId(int id);
    UsuarioModel ValidaUser(string login,string senha);
}
