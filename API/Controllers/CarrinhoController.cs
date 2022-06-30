using API.Dtos;
using AutoMapper;
using Main.Interfaces;
using Main.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CarrinhoController : BaseApiController
    {
        private readonly ICarrinhoRepository _carrinhoRepository;
        private readonly IMapper _mapper;
        public CarrinhoController(ICarrinhoRepository carrinhoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _carrinhoRepository = carrinhoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CarrinhoCliente>> GetCarrinhoById (string id) 
        {
            var carrinho = await _carrinhoRepository.GetCarrinhoAsync(id);

            return Ok(carrinho ?? new CarrinhoCliente(id));
        }

        [HttpPost]
        public async Task<ActionResult<CarrinhoCliente>> UpdateCarrinho (CarrinhoClienteDto carrinho)
        {
            var carrinhoCliente = _mapper.Map<CarrinhoCliente>(carrinho);

            var updatedCarrinho = await _carrinhoRepository.UpdateCarrinhoAsync(carrinhoCliente);

            return Ok(updatedCarrinho);
        }

        [HttpDelete]
        public async Task DeleteCarrinho (string id) 
        {
            await _carrinhoRepository.DeleteCarrinhoAsync(id);
        }
    }
}