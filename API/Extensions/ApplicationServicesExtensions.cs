using API.Errors;
using Support.Services;
using Main.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Support.Data;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {  
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };    

                    return new BadRequestObjectResult(errorResponse);
                };
            });
            return services;
        }
    }
}