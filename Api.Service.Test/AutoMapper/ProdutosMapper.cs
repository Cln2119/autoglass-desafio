using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Produtos;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class ProdutosMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possível Mapear os Modelos")]
        public void E_Possivel_Mapear_os_Modelos()
        {
            var model = new ProdutosModel
            {
                Id = 1,
                Descricao = "Vidro",
                Situacao = "Ativo",
                DataFabricacao = "2024-01-29",
                DataValidade = "2025-01-29",
                CodigoFornecedor = "123456",
                DescricaoFornecedor = "Fornecedor Vidros",
                CnpjFornecedor = "00.000.000/0001-01",
                DataCriacao = DateTime.UtcNow,
                DataAtualizacao = DateTime.UtcNow
            };

            var listaEntity = new List<ProdutosEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new ProdutosEntity
                {
                    Id = 1,
                    Descricao = "Vidro",
                    Situacao = "Ativo",
                    DataFabricacao = "2024-01-29",
                    DataValidade = "2025-01-29",
                    CodigoFornecedor = "123456",
                    DescricaoFornecedor = "Fornecedor Vidros",
                    CnpjFornecedor = "00.000.000/0001-01",
                    DataCriacao = DateTime.UtcNow,
                    DataAtualizacao = DateTime.UtcNow
                };
                listaEntity.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<ProdutosEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Descricao, model.Descricao);
            Assert.Equal(entity.Situacao, model.Situacao);
            Assert.Equal(entity.DataFabricacao, model.DataFabricacao);
            Assert.Equal(entity.DataValidade, model.DataValidade);
            Assert.Equal(entity.CodigoFornecedor, model.CodigoFornecedor);
            Assert.Equal(entity.DescricaoFornecedor, model.DescricaoFornecedor);
            Assert.Equal(entity.CnpjFornecedor, model.CnpjFornecedor);
            Assert.Equal(entity.DataCriacao, model.DataCriacao);
            Assert.Equal(entity.DataAtualizacao, model.DataAtualizacao);

            //Entity para Dto
            var produtosDto = Mapper.Map<ProdutosDto>(entity);
            Assert.Equal(produtosDto.Id, entity.Id);
            Assert.Equal(produtosDto.Descricao, entity.Descricao);
            Assert.Equal(produtosDto.Situacao, entity.Situacao);
            Assert.Equal(produtosDto.DataFabricacao, entity.DataFabricacao);
            Assert.Equal(produtosDto.DataValidade, entity.DataValidade);
            Assert.Equal(produtosDto.CodigoFornecedor, entity.CodigoFornecedor);
            Assert.Equal(produtosDto.DescricaoFornecedor, entity.DescricaoFornecedor);
            Assert.Equal(produtosDto.CnpjFornecedor, entity.CnpjFornecedor);
            Assert.Equal(produtosDto.DataCriacao, entity.DataCriacao);

            var listaDto = Mapper.Map<List<ProdutosDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);             
                Assert.Equal(listaDto[i].Descricao, listaEntity[i].Descricao);
                Assert.Equal(listaDto[i].Situacao, listaEntity[i].Situacao);
                Assert.Equal(listaDto[i].DataFabricacao, listaEntity[i].DataFabricacao);
                Assert.Equal(listaDto[i].DataValidade, listaEntity[i].DataValidade);
                Assert.Equal(listaDto[i].CodigoFornecedor, listaEntity[i].CodigoFornecedor);
                Assert.Equal(listaDto[i].DescricaoFornecedor, listaEntity[i].DescricaoFornecedor);
                Assert.Equal(listaDto[i].CnpjFornecedor, listaEntity[i].CnpjFornecedor);
                Assert.Equal(listaDto[i].DataCriacao, listaEntity[i].DataCriacao);
            }

            var produtosDtoCreateResult = Mapper.Map<ProdutosDtoCreateResult>(entity);
            Assert.Equal(produtosDtoCreateResult.Id, entity.Id);
            Assert.Equal(produtosDtoCreateResult.Descricao, entity.Descricao);
            Assert.Equal(produtosDtoCreateResult.Situacao, entity.Situacao);
            Assert.Equal(produtosDtoCreateResult.DataFabricacao, entity.DataFabricacao);
            Assert.Equal(produtosDtoCreateResult.DataValidade, entity.DataValidade);
            Assert.Equal(produtosDtoCreateResult.CodigoFornecedor, entity.CodigoFornecedor);
            Assert.Equal(produtosDtoCreateResult.DescricaoFornecedor, entity.DescricaoFornecedor);
            Assert.Equal(produtosDtoCreateResult.CnpjFornecedor, entity.CnpjFornecedor);
            Assert.Equal(produtosDtoCreateResult.DataCriacao, entity.DataCriacao);

            var produtosDtoUpdateResult = Mapper.Map<ProdutosDtoUpdateResult>(entity);
            Assert.Equal(produtosDtoUpdateResult.Id, entity.Id);
            Assert.Equal(produtosDtoUpdateResult.Descricao, entity.Descricao);
            Assert.Equal(produtosDtoUpdateResult.Situacao, entity.Situacao);
            Assert.Equal(produtosDtoUpdateResult.DataFabricacao, entity.DataFabricacao);
            Assert.Equal(produtosDtoUpdateResult.DataValidade, entity.DataValidade);
            Assert.Equal(produtosDtoUpdateResult.CodigoFornecedor, entity.CodigoFornecedor);
            Assert.Equal(produtosDtoUpdateResult.DescricaoFornecedor, entity.DescricaoFornecedor);
            Assert.Equal(produtosDtoUpdateResult.CnpjFornecedor, entity.CnpjFornecedor);
            Assert.Equal(produtosDtoUpdateResult.DataCriacao, entity.DataCriacao);

            //Dto para Model
            var produtosModel = Mapper.Map<ProdutosModel>(produtosDto);
            Assert.Equal(produtosModel.Id, produtosDto.Id);
            Assert.Equal(produtosModel.Descricao, produtosDto.Descricao);
            Assert.Equal(produtosModel.Situacao, produtosDto.Situacao);
            Assert.Equal(produtosModel.DataFabricacao, produtosDto.DataFabricacao);
            Assert.Equal(produtosModel.DataValidade, produtosDto.DataValidade);
            Assert.Equal(produtosModel.CodigoFornecedor, produtosDto.CodigoFornecedor);
            Assert.Equal(produtosModel.DescricaoFornecedor, produtosDto.DescricaoFornecedor);
            Assert.Equal(produtosModel.CnpjFornecedor, produtosDto.CnpjFornecedor);
            Assert.Equal(produtosModel.DataCriacao, produtosDto.DataCriacao);

            var produtosDtoCreate = Mapper.Map<ProdutosDtoCreate>(produtosModel);       
            Assert.Equal(produtosDtoCreate.Descricao, produtosModel.Descricao);
            Assert.Equal(produtosDtoCreate.Situacao, produtosModel.Situacao);
            Assert.Equal(produtosDtoCreate.DataFabricacao, produtosModel.DataFabricacao);
            Assert.Equal(produtosDtoCreate.DataValidade, produtosModel.DataValidade);
            Assert.Equal(produtosDtoCreate.CodigoFornecedor, produtosModel.CodigoFornecedor);
            Assert.Equal(produtosDtoCreate.DescricaoFornecedor, produtosModel.DescricaoFornecedor);
            Assert.Equal(produtosDtoCreate.CnpjFornecedor, produtosModel.CnpjFornecedor);

            var produtosDtoUpdate = Mapper.Map<ProdutosDtoUpdate>(produtosModel);
            Assert.Equal(produtosDtoUpdate.Id, produtosModel.Id);     
            Assert.Equal(produtosDtoUpdate.Descricao, produtosModel.Descricao);
            Assert.Equal(produtosDtoUpdate.Situacao, produtosModel.Situacao);
            Assert.Equal(produtosDtoUpdate.DataFabricacao, produtosModel.DataFabricacao);
            Assert.Equal(produtosDtoUpdate.DataValidade, produtosModel.DataValidade);
            Assert.Equal(produtosDtoUpdate.CodigoFornecedor, produtosModel.CodigoFornecedor);
            Assert.Equal(produtosDtoUpdate.DescricaoFornecedor, produtosModel.DescricaoFornecedor);
            Assert.Equal(produtosDtoUpdate.CnpjFornecedor, produtosModel.CnpjFornecedor);

        }
    }
}
