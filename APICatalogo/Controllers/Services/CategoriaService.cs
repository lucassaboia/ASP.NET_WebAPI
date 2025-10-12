using APICatalogo.Context;
using APICatalogo.Models.Base;
using APICatalogo.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public interface ICategoriaService
{
    Task<BaseReturn<Categoria>> CriarCategoria(CategoriaRequest request);
    Task<List<Categoria?>> GetAllCategorias();
    Categoria GetCategoria(CategoriaRequest request);
    Task<Categoria?> GetCategoriaById(int id);
    Task<BaseReturn<Categoria?>> EditarCategoriaAsync(int id, CategoriaRequest request);
    Task<BaseReturn<bool>> DeleteCategoria(int id);
}

public class CategoriaService : ICategoriaService
{
    private readonly AppDbContext _context;

    public CategoriaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Categoria?>> GetAllCategorias()
    {
        return await _context.Categorias.Where(p => p.Ativo).ToListAsync();
    }
    public async Task<Categoria?> GetCategoriaById(int id)
    {
        return await _context.Categorias
                .Where(p => p.Id == id && p.Ativo)
                .SingleOrDefaultAsync();
    }
    public Categoria GetCategoria(CategoriaRequest request)
    {
        var Categoria = new Categoria(
            request.Nome
        );

        Categoria.DataInsercao = DateTime.Now;
        Categoria.Ativo = true;

        return Categoria;
    }
    public async Task<BaseReturn<Categoria>> CriarCategoria(CategoriaRequest request)
    {
        var Categoria = new Categoria(
            request.Nome
        );

        Categoria.DataInsercao = DateTime.Now;
        Categoria.Ativo = true;

        _context.Categorias.Add(Categoria);
        
        try
        {

        }
        catch(DbUpdateConcurrencyException ex)
        {
            throw ex.InnerException ?? ex;
        }

        await _context.SaveChangesAsync();

        return BaseReturn<Categoria>.Ok(Categoria);
    }

    public async Task<BaseReturn<Categoria?>> EditarCategoriaAsync(int id, CategoriaRequest request)
    {
        var categoriaExistente = await _context.Categorias.FindAsync(id);

        if (categoriaExistente == null)
            return BaseReturn<Categoria>.Falha("Categoria não encontrado.");

        var categoriaAtualizado = new Categoria(
            request.Nome
        );

        categoriaExistente.DefinirImagem(request.ImagemUrl);
        categoriaExistente.Update(categoriaAtualizado);
        categoriaExistente.DataAlteracao = DateTime.Now;
        categoriaExistente.Ativo = true;


        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw ex.InnerException ?? ex;
        }

        return BaseReturn<Categoria>.Ok(categoriaExistente);
    }

    public async Task<BaseReturn<bool>> DeleteCategoria(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);

        if (categoria == null)
            return BaseReturn<bool>.Falha("Categoria não encontrado.");

        categoria.Ativo = false;
        categoria.DataExclusao = DateTime.Now;
        await _context.SaveChangesAsync();

        return BaseReturn<bool>.Ok(true);
    }
}
