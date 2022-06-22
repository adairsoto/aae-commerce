using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly LojaContext _context;
        public ProdutosController(LojaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> ListarProdutos()
        {
            var produtos = await _context.Produtos.ToListAsync();
            
            return Ok(produtos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> PegarProdutoId(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> SalvarProduto(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarProduto(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> ExcluirProduto(int id)
        {
            Produto produto = await _context.Produtos.FindAsync(id);
            _context.Remove(produto);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}