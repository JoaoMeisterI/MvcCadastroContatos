using MvcCadastroContatos.Models;

namespace MvcCadastroContatos.Repositorio
{
    public interface IContatosRepositorio
    {
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int contato);
        List<ContatoModel> BuscarAllContatos();
        ContatoModel BuscaContatoId(int id);

    }
}
