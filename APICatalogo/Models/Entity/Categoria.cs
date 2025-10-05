using APICatalogo.Models.Base;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APICatalogo.Models.Entity;

public class Categoria : BaseAll
{
    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }
    [Required]
    public string? Nome { get; set; }
    [Required]
    public string? ImagemUrl { get; set; }

    public ICollection<Produto>? Produtos { get; set; }
}
