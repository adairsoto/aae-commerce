using API.Dtos;
using AutoMapper;
using Main.Models;
using Main.Models.Identity;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Produto, ProdutoToReturnDto>()
                .ForMember(d => d.ProdutoMarca, o => o.MapFrom(s => s.ProdutoMarca.Nome))
                .ForMember(d => d.ProdutoCategoria, o => o.MapFrom(s => s.ProdutoCategoria.Nome))
                .ForMember(d => d.ImagemUrl, o => o.MapFrom<ProdutoUrlResolver>());
            CreateMap<Address, AddressDto>().ReverseMap(); 
            CreateMap<CarrinhoClienteDto, CarrinhoCliente>();
            CreateMap<CarrinhoItemDto, CarrinhoItem>();   
        }
    }
}