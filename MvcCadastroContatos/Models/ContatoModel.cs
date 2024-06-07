using System.ComponentModel.DataAnnotations;

namespace MvcCadastroContatos.Models;

public class ContatoModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Nome: Campo Obrigatório!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Email: Campo Obrigatório!")]
    [EmailAddress(ErrorMessage = "Email: Formato inválido!")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Telefone: Campo Obrigatório!")]
    [Phone(ErrorMessage = "Telefone: Formato inválido!")]
    public string Telefone { get; set; }   
    public UsuarioModel usuario { get; set; }
}
