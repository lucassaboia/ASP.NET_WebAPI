using APICatalogo.Context;
using APICatalogo.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ProdutoService _service;


        public ProdutosController(ProdutoService service, AppDbContext context)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutosById()
        {
            return await _context.Produtos.ToListAsync();
        }

        [HttpGet("{id:int}", Name="GetProduto")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Produto>> CreateProduto(ProdutoRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); 
    
            var produto = _service.CriarProduto(request);
            
            if (!isCategoriaValid(produto.CategoriaId))
                return BadRequest("CategoriaId inválido.");

            _context.Produtos.Add(produto);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduto(int id, ProdutoRequest request)
        {
            if (!isCategoriaValid(request.CategoriaId))
                return BadRequest("CategoriaId inserida inválida.");

            var produtoExistente = await _context.Produtos.FindAsync(id);
            if (produtoExistente is null)
                return BadRequest("ID de produto inexistente");

            produtoExistente = _service.EditarProduto(produtoExistente, request);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            produto.Ativo = false;
            produto.DataExclusao = DateTime.Now;
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool isCategoriaValid(int? id)
        {
            if (id is null)
                return true;

            return _context.Categorias.Any(e => e.Id == id);
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}