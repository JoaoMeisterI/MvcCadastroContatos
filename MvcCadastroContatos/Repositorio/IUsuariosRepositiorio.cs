using MvcCadastroContatos.Models;

namespace MvcCadastroContatos.Repositorio;

public interface IUsuariosRepositiorio
{
    UsuarioModel Adicionar(UsuarioModel usuario);
    UsuarioModel Atualizar(UsuarioModel usuario);
    UsuarioModel BuscarUserId(int id);
}
