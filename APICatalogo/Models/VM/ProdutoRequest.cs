using APICatalogo.Models.Base;
using System.ComponentModel.DataAnnotations;

public class ProdutoRequest : BaseRequest
{

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Descricao { get; set; }

    [Required]
    public decimal Preco { get; set; }

    [Required]
    public string ImagemUrl { get; set; }
    [Required]
    public float Estoque { get; set; }
    public int? CategoriaId { get; set; }
}
