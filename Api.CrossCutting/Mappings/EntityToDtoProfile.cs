using Api.Domain.Dtos.Produtos;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<ProdutosDto, ProdutosEntity>()
               .ReverseMap();

            CreateMap<ProdutosDtoCreateResult, ProdutosEntity>()
               .ReverseMap();

            CreateMap<ProdutosDtoUpdateResult, ProdutosEntity>()
               .ReverseMap();

        }
    }
}
