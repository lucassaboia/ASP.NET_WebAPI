using APICatalogo.Models.Base;
using System.ComponentModel.DataAnnotations;

public class CategoriaRequest : BaseRequest
{

    [Required]
    public string Nome { get; set; }
    public string? ImagemUrl { get; set; }
}
