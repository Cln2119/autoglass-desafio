using Api.Domain.Dtos.Produtos;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            #region Produtos
            CreateMap<ProdutosModel, ProdutosDto>()
                .ReverseMap();
            CreateMap<ProdutosModel, ProdutosDtoCreate>()
                .ReverseMap();
            CreateMap<ProdutosModel, ProdutosDtoUpdate>()
                .ReverseMap();
            #endregion                        

        }

    }
}
