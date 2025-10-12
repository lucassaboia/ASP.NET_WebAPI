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
        private readonly ProdutoService _service;


        public ProdutosController(ProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetAllProdutos()
        {
            var produto = await _service.GetAllProdutos();

            return Ok(produto);
        }

        [HttpGet("{id:int}", Name= "GetProdutoById")]
        public async Task<ActionResult<Produto>> GetProdutoById(int id)
        {
            var produto = await _service.GetProdutoById(id);

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
    
            var produto = await _service.CriarProduto(request);
            
            if (produto is null)
                return BadRequest("CategoriaId inválido.");

            return CreatedAtAction(nameof(GetProdutoById), new { id = produto.Dados.Id }, produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduto(int id, ProdutoRequest request)
        {
            var resultado = await _service.EditarProdutoAsync(id, request);

            if (!resultado.Sucesso)
                return BadRequest(resultado.Mensagem);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var resultado = await _service.DeleteProduto(id);
            
            if (!resultado.Sucesso)
                return BadRequest(resultado.Mensagem);            

            return NoContent();
        }      
    }
}