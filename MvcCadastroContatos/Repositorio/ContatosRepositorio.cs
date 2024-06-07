using Microsoft.EntityFrameworkCore;
using MvcCadastroContatos.Data;
using MvcCadastroContatos.Models;

namespace MvcCadastroContatos.Repositorio
{
    public class ContatosRepositorio : IContatosRepositorio
    {
        //A gente vai injetar o contexto por meio
        // de um construtor, esse contexto vai ser nossa interação direta com o DB
        private readonly BancoContext _bancoContext;
        public ContatosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            //Gravar em um banco de dados
            _bancoContext.Contatos.Add(contato);
            //comitando a info
            _bancoContext.SaveChanges();
            return contato;
        }
        public ContatoModel Atualizar(ContatoModel contato)
        {
            //Buscando por Id
            ContatoModel contatoAtualizar = BuscaContatoId(contato.Id);

            //Verificando se é nulo
            if (contatoAtualizar == null) throw new System.Exception("Não foi possível realizar a atualização do contato");
           
            //Atualizando os campos
            contatoAtualizar.Name = contato.Name;
            contatoAtualizar.Email = contato.Email;
            contatoAtualizar.Telefone = contato.Telefone;

            //Gerando o Update
            _bancoContext.Contatos.Update(contatoAtualizar);
            _bancoContext.SaveChanges();
            return contatoAtualizar;
        }
        //PRECISAMOS BUSCAR O CONTATO POR ID
        public ContatoModel BuscaContatoId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x=>x.Id==id);
        }
        public List<ContatoModel> BuscarAllContatos()
        {
            //Lista tudo que tem no db
            return _bancoContext.Contatos.ToList();
        }
        public bool Apagar(int id)
        {

            ContatoModel contatoDelete = BuscaContatoId(id);

            if (contatoDelete == null) throw new System.Exception("Não foi possível realizar a Exclusão do contato");

            _bancoContext.Contatos.Remove(contatoDelete);
            _bancoContext.SaveChanges();

            return true;

        }
    }
}
