using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Main.Interfaces;
using Main.Models;
using Main.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Support.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IGenericRepository<Produto> _produtosRepo;
        private readonly IGenericRepository<ProdutoCategoria> _produtoCategoriaRepo;
        private readonly IGenericRepository<ProdutoMarca> _produtoMarcaRepo;
        private readonly IMapper _mapper;

        public ProdutosController(IGenericRepository<Produto> produtosRepo,
        IGenericRepository<ProdutoMarca> produtoMarcaRepo, IGenericRepository<ProdutoCategoria> produtoCategoriaRepo,
        IMapper mapper)
        {
            _mapper = mapper;
            _produtoMarcaRepo = produtoMarcaRepo;
            _produtoCategoriaRepo = produtoCategoriaRepo;
            _produtosRepo = produtosRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProdutoToReturnDto>>> ListarProdutos()
        {
            var spec = new ProdutoMarcaCatSpecification();
            
            var produtos = await _produtosRepo.ListAsync(spec);
            
            return Ok(_mapper.Map<IReadOnlyList<Produto>, IReadOnlyList<ProdutoToReturnDto>>(produtos));
        } 
       
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoToReturnDto>> PegarProdutoId(int id)
        {
            var spec = new ProdutoMarcaCatSpecification(id);

            var produto = await _produtosRepo.GetEntityWithSpec(spec);

            return _mapper.Map<Produto, ProdutoToReturnDto>(produto);
        }

        [HttpGet("marcas")]
        public async Task<ActionResult<IReadOnlyList<ProdutoMarca>>> ListarMarcas()
        {
            return Ok(await _produtoMarcaRepo.ListAllAsync());
        }

        [HttpGet("categ")]
        public async Task<ActionResult<IReadOnlyList<ProdutoCategoria>>> ListarCategorias()
        {
            return Ok(await _produtoCategoriaRepo.ListAllAsync());
        }
    }
}