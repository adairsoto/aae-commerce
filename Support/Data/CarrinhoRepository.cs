using System.Text.Json;
using Main.Interfaces;
using Main.Models;
using StackExchange.Redis;

namespace Support.Data
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly IDatabase _database;
        public CarrinhoRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteCarrinhoAsync(string carrinhoId)
        {
            return await _database.KeyDeleteAsync(carrinhoId);
        }

        public async Task<CarrinhoCliente> GetCarrinhoAsync(string carrinhoId)
        {
            var data = await _database.StringGetAsync(carrinhoId);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CarrinhoCliente>(data);
        }

        public async Task<CarrinhoCliente> UpdateCarrinhoAsync(CarrinhoCliente carrinho)
        {
            var created = await _database.StringSetAsync(carrinho.Id, JsonSerializer.Serialize(carrinho), TimeSpan.FromDays(30));

            if (!created) return null;

            return await GetCarrinhoAsync(carrinho.Id);
        }
    }
}