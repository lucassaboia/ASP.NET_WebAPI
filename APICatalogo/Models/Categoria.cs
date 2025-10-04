using APICatalogo.Models.Base;
using System.Collections.ObjectModel;

namespace APICatalogo.Models;

public class Categoria : BaseAll
{
    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }
    public string? Nome { get; set; }

    public ICollection<Produto>? Produtos { get; set; }
}
