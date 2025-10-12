using APICatalogo.Context;
using APICatalogo.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public interface IProdutoService
{
    Task<BaseReturn<Produto>> CriarProduto(ProdutoRequest request);
    Task<List<Produto?>> GetAllProdutos();
    Produto GetProduto(ProdutoRequest request);
    Task<Produto?> GetProdutoById(int id);
    Task<BaseReturn<Produto?>> EditarProdutoAsync(int id, ProdutoRequest request);
    Task<BaseReturn<bool>> DeleteProduto(int id);
}

public class ProdutoService : IProdutoService
{
    private readonly AppDbContext _context;

    public ProdutoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Produto?>> GetAllProdutos()
    {
        return await _context.Produtos.Where(p => p.Ativo).ToListAsync();
    }
    public async Task<Produto?> GetProdutoById(int id)
    {
        return await _context.Produtos
                .Where(p => p.Id == id && p.Ativo)
                .SingleOrDefaultAsync();
    }
    public Produto GetProduto(ProdutoRequest request)
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
    public async Task<BaseReturn<Produto>> CriarProduto(ProdutoRequest request)
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

        if (!isCategoriaValid(produto.CategoriaId))
            return BaseReturn<Produto>.Falha("CategoriaId inserida inválida.");

        _context.Produtos.Add(produto);       
        await _context.SaveChangesAsync();

        return BaseReturn<Produto>.Ok(produto);
    }

    public async Task<BaseReturn<Produto?>> EditarProdutoAsync(int id, ProdutoRequest request)
    {
        var produtoExistente = await _context.Produtos.FindAsync(id);

        if (produtoExistente == null)
            return BaseReturn<Produto>.Falha("Produto não encontrado.");

        if (!isCategoriaValid(request.CategoriaId))
            return BaseReturn<Produto>.Falha("CategoriaId inserida inválida.");

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


        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw ex.InnerException ?? ex;
        }

        return BaseReturn<Produto>.Ok(produtoExistente);
    }

    public async Task<BaseReturn<bool>> DeleteProduto(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
            return BaseReturn<bool>.Falha("Produto não encontrado.");

        produto.Ativo = false;
        produto.DataExclusao = DateTime.Now;
        await _context.SaveChangesAsync();

        return BaseReturn<bool>.Ok(true);
    }


    private bool isCategoriaValid(int? id)
    {
        if (id is null)
            return true;

        return _context.Categorias.Any(e => e.Id == id);
    }

}
