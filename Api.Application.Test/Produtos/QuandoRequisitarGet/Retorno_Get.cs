using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Produtos;
using Api.Domain.Interfaces.Services.Produtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarGet
{
    public class Retorno_Get
    {
        private ProdutosController _controller;

        [Fact(DisplayName = "É possível Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<IProdutosService>();
            var descricao = "Vidro";
            var situacao = "Ativo";
            var dataFabricacao = "2024-01-29";
            var dataValidade = "2025-01-29";
            var codigoFornecedor = "123456";
            var descricaoFornecedor = "Fornecedor Vidros";
            var cnpjFornecedor = "00.000.000/0001-01";

            serviceMock.Setup(m => m.Get(It.IsAny<int>())).ReturnsAsync(
                 new ProdutosDto
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
            var result = await _controller.Recuperar(It.IsAny<int>());
            Assert.True(result is OkObjectResult);
            var resultValue = ((OkObjectResult)result).Value as ProdutosDto;
            Assert.NotNull(resultValue);
            Assert.Equal(descricao, resultValue.Descricao);
            Assert.Equal(situacao, resultValue.Situacao);
            Assert.Equal(dataFabricacao, resultValue.DataFabricacao);
            Assert.Equal(dataValidade, resultValue.DataValidade);
            Assert.Equal(codigoFornecedor, resultValue.CodigoFornecedor);
            Assert.Equal(descricaoFornecedor, resultValue.DescricaoFornecedor);
            Assert.Equal(cnpjFornecedor, resultValue.CnpjFornecedor);

        }
    }
}
