using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Produtos;
using Api.Domain.Interfaces.Services.Produtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarUpdate
{
    public class Retorno_BadRequest
    {
        private ProdutosController _controller;

        [Fact(DisplayName = "É possível Realizar o Updated.")]
        public async Task E_Possivel_Invocar_a_Controller_Update()
        {
            var serviceMock = new Mock<IProdutosService>();          
            var descricao = "Vidro";
            var situacao = "Ativo";
            var dataFabricacao = "2024-01-29";
            var dataValidade = "2025-01-29";
            var codigoFornecedor = "123456";
            var descricaoFornecedor = "Fornecedor Vidros";
            var cnpjFornecedor = "00.000.000/0001-01";

            serviceMock.Setup(m => m.Put(It.IsAny<ProdutosDtoUpdate>())).ReturnsAsync(
                new ProdutosDtoUpdateResult
                {
                    Id = 1,
                    Descricao = descricao,
                    Situacao = situacao,
                    DataFabricacao = dataFabricacao,
                    DataValidade = dataValidade,
                    CodigoFornecedor = codigoFornecedor,
                    DescricaoFornecedor = descricaoFornecedor,
                    CnpjFornecedor = cnpjFornecedor,
                    DataCriacao = DateTime.UtcNow
                }
            );

            _controller = new ProdutosController(serviceMock.Object);
            _controller.ModelState.AddModelError("Situacao", "Precisa estar Inativo");
            var produtosDtoUpdate = new ProdutosDtoUpdate
            {
                Id = 1,
                Descricao = descricao,
                Situacao = situacao,
                DataFabricacao = dataFabricacao,
                DataValidade = dataValidade,
                CodigoFornecedor = codigoFornecedor,
                DescricaoFornecedor = descricaoFornecedor,
                CnpjFornecedor = cnpjFornecedor
            };

            var result = await _controller.Editar(produtosDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
