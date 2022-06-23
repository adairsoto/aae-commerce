using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Interfaces;
using Main.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Support.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _repo;
        public ProdutosController(IProdutoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> ListarProdutos()
        {
            var produtos = await _repo.GetProdutosAsync();
            
            return Ok(produtos);
        } 
       
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> PegarProdutoId(int id)
        {
            return await _repo.GetProdutoByIdAsync(id);
        }

        [HttpGet("marcas")]
        public async Task<ActionResult<IReadOnlyList<ProdutoMarca>>> ListarMarcas()
        {
            return Ok(await _repo.GetProdutoMarcasAsync());
        }

        [HttpGet("categ")]
        public async Task<ActionResult<IReadOnlyList<ProdutoCategoria>>> ListarCategorias()
        {
            return Ok(await _repo.GetProdutoCategoriasAsync());
        }
    }
}