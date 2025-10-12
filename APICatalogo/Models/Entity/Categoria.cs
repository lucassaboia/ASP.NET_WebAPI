using APICatalogo.Models.Base;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APICatalogo.Models.Entity;

public class Categoria : BaseAll
{
    public Categoria(string nome)
    {
        Produtos = new Collection<Produto>();
        Nome = nome;
    }
    public string Nome { get; set; }
    public string? ImagemUrl { get; set; }
    public ICollection<Produto>? Produtos { get; set; }
    public void DefinirImagem(string? imagemUrl) => ImagemUrl = imagemUrl;
    public void Update(Categoria categoria)
    {
        Nome = categoria.Nome;
    }
}
