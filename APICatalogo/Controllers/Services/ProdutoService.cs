using APICatalogo.Models.Entity;

public interface IProdutoService
{
    Produto CriarProduto(ProdutoRequest request);
}

public class ProdutoService : IProdutoService
{
    public ProdutoService()
    {
    }

    public Produto CriarProduto(ProdutoRequest request)
    {
        var produto = new Produto(
            request.Nome, 
            request.Descricao, 
            request.Preco,
            request.Estoque
        );

        produto.DefinirImagem(request.ImagemUrl);
        produto.DefinirCategoriaId(request.CategoriaId);
        produto.DataInsercao = DateTime.Now;
        produto.Ativo = true;

        return produto;
    }

    public Produto EditarProduto(Produto produtoExistente, ProdutoRequest request)
    {
        var produtoAtualizado = new Produto(
            request.Nome,
            request.Descricao,
            request.Preco,
            request.Estoque
        );

        produtoExistente.DefinirImagem(request.ImagemUrl);
        produtoExistente.DefinirCategoriaId(request.CategoriaId);
        produtoExistente.Update(produtoAtualizado);

        produtoExistente.DataAlteracao = DateTime.Now;
        produtoExistente.Ativo = true;

        return produtoExistente;
    }

}
