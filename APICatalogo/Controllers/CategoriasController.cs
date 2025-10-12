using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICatalogo.Context;
using APICatalogo.Models.Entity;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriasController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            var resultado = await _service.GetAllCategorias();

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoriaById(int id)
        {
            var categoria = await _service.GetCategoriaById(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> CreateCategoria(CategoriaRequest categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _service.CriarCategoria(categoria);

            if (!resultado.Sucesso)
                return BadRequest(resultado.Mensagem);
            

            return CreatedAtAction("GetCategoriaById", new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCategoria(int id, CategoriaRequest categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _service.EditarCategoriaAsync(id, categoria);

            if (!resultado.Sucesso)
                return BadRequest(resultado.Mensagem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var resultado = await _service.DeleteCategoria(id);

            if (!resultado.Sucesso)
                return BadRequest(resultado.Mensagem);

            return NoContent();
        }
    }
}