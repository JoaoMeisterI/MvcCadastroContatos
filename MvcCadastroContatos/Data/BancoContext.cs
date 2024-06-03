using Microsoft.EntityFrameworkCore;
using MvcCadastroContatos.Models;
namespace MvcCadastroContatos.Data;

public class BancoContext: DbContext
{
    //Herdando o contexto, esse options vai para dentro do dbcontext
    public BancoContext(DbContextOptions<BancoContext> options) : base(options)
    {

    }
    
    //Passando o Controller Contato para o dbset, criando a tabela Contato
    public DbSet<ContatoModel> Contatos { get; set; }
    public DbSet<UsuarioModel> Usuarios { get; set; }
}
