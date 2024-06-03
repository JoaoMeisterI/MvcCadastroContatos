using MvcCadastroContatos.Models;

namespace MvcCadastroContatos.Repositorio;

public interface IUsuariosRepositiorio
{
    UsuarioModel Adicionar(UsuarioModel usuario);
}
