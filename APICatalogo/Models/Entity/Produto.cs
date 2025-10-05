using APICatalogo.Models.Base;
using APICatalogo.Models.Entity;

public class Produto : BaseAll
{
    public Produto(string nome, string descricao, decimal preco, float estoque)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Estoque = estoque;
    }

    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public decimal Preco { get; private set; }
    public float Estoque { get; private set; }
    public int? CategoriaId { get; private set; }
    public string? ImagemUrl { get; private set; }
    public Categoria? Categoria { get; private set; }

    public void DefinirCategoriaId(int? categoriaId) => CategoriaId = categoriaId;

    public void DefinirImagem(string? imagemUrl) => ImagemUrl = imagemUrl;

    public void DefinirCategoria(Categoria? categoria) => Categoria = categoria;

    public void Update(Produto categoria)
    {
        Nome = categoria.Nome;
        Descricao = categoria.Descricao;
        Preco = categoria.Preco;
        Estoque = categoria.Estoque;
    }

}
