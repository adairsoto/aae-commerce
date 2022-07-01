using System.Text.Json;
using Main.Models;
using Main.Models.OrderAggregate;
using Microsoft.Extensions.Logging;

namespace Support.Data
{
    public class LojaContextSeed
    {
        public static async Task SeedAsync(LojaContext context, ILoggerFactory loggerFactory)
        {
            try 
            {
                if (!context.ProdutoMarcas.Any())
                {
                    var marcasData = File.ReadAllText("../Support/Data/SeedData/marcas.json");

                    var marcas = JsonSerializer.Deserialize<List<ProdutoMarca>>(marcasData);

                    foreach (var item in marcas)
                    {
                        context.ProdutoMarcas.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.ProdutoCategorias.Any())
                {
                    var categData = File.ReadAllText("../Support/Data/SeedData/categ.json");

                    var categ = JsonSerializer.Deserialize<List<ProdutoCategoria>>(categData);

                    foreach (var item in categ)
                    {
                        context.ProdutoCategorias.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Produtos.Any())
                {
                    var produtosData = File.ReadAllText("../Support/Data/SeedData/produtos.json");

                    var produtos = JsonSerializer.Deserialize<List<Produto>>(produtosData);

                    foreach (var item in produtos)
                    {
                        context.Produtos.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.DeliveryMethods.Any())
                {
                    var dmData = File.ReadAllText("../Support/Data/SeedData/delivery.json");
                    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);

                    foreach (var item in methods)
                    {
                        context.DeliveryMethods.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex) 
            {
                var logger = loggerFactory.CreateLogger<LojaContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}