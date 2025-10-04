using APICatalogo.Models.Base;

namespace APICatalogo.Models;

public class Produto : BaseAll
{
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public float Estoque { get; set; }
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
}
