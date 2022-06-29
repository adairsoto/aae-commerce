using Main.Interfaces;
using Main.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CarrinhoController : BaseApiController
    {
        private readonly ICarrinhoRepository _carrinhoRepository;
        public CarrinhoController(ICarrinhoRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CarrinhoCliente>> GetCarrinhoById (string id) 
        {
            var carrinho = await _carrinhoRepository.GetCarrinhoAsync(id);

            return Ok(carrinho ?? new CarrinhoCliente(id));
        }

        [HttpPost]
        public async Task<ActionResult<CarrinhoCliente>> UpdateCarrinho (CarrinhoCliente carrinho)
        {
            var updatedCarrinho = await _carrinhoRepository.UpdateCarrinhoAsync(carrinho);

            return Ok(updatedCarrinho);
        }

        [HttpDelete]
        public async Task DeleteCarrinho (string id) 
        {
            await _carrinhoRepository.DeleteCarrinhoAsync(id);
        }
    }
}