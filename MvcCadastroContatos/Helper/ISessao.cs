using MvcCadastroContatos.Models;

namespace MvcCadastroContatos.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usuario);
        void RemoverSessaoUsuario();
         UsuarioModel BuscarSessaoUsuario();
    }
}
