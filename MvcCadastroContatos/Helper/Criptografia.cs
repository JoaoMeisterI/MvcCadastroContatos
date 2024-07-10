using Newtonsoft.Json;
using MvcCadastroContatos.Models;
using System.Security.Cryptography;
using System.Text;

namespace MvcCadastroContatos.Helper;
public static class Criptografia
{
    public static string GerarHash(this string valor)
    {
        var hash = SHA1.Create();
        var encoding = new ASCIIEncoding();
        //pegar nosso valor e transforma em um array de bytes
        var array = encoding.GetBytes(valor);
        array = hash.ComputeHash(array);
        var strHexa= new StringBuilder();
        //Fazer um for para montar o hash
        foreach (var item in array)
        {
            strHexa.Append(item.ToString("x2"));
        }
        return strHexa.ToString();
    }
}