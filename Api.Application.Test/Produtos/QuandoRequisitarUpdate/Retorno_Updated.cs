using System;
using System.Globalization;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Produtos;
using Api.Domain.Interfaces.Services.Produtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarUpdate
{
    public class Retorno_Updated
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
            var cnpjFornecedor = "00000000000101";

            string formato = "yyyy-MM-dd";
            DateTime dataFabricacaoFormatado = DateTime.ParseExact(dataFabricacao, formato, CultureInfo.InvariantCulture);
            DateTime dataValidadeFormatado = DateTime.ParseExact(dataValidade, formato, CultureInfo.InvariantCulture);

            if (dataFabricacaoFormatado >= dataValidadeFormatado)
            {
                _controller = new ProdutosController(serviceMock.Object);
                _controller.ModelState.AddModelError("DataFabricacao", "O valor da data de fabricação não pode ser maior que a data de validade");
            }

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
                    CnpjFornecedor = cnpjFornecedor.Replace(".", "").Replace("-", "").Replace("/", ""),
                    DataCriacao = DateTime.UtcNow
                }
            );

            _controller = new ProdutosController(serviceMock.Object);

            var produtosDtoUpdate = new ProdutosDtoUpdate
            {
                Id = 1,
                Descricao = descricao,
                Situacao = situacao,
                DataFabricacao = dataFabricacao,
                DataValidade = dataValidade,
                CodigoFornecedor = codigoFornecedor,
                DescricaoFornecedor = descricaoFornecedor,
                CnpjFornecedor = cnpjFornecedor,
            };

            var result = await _controller.Editar(produtosDtoUpdate);
            Assert.True(result is OkObjectResult);

            ProdutosDtoUpdateResult resultValue = ((OkObjectResult)result).Value as ProdutosDtoUpdateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(produtosDtoUpdate.Descricao, resultValue.Descricao);
            Assert.Equal(produtosDtoUpdate.Situacao, resultValue.Situacao);
            Assert.Equal(produtosDtoUpdate.DataFabricacao, resultValue.DataFabricacao);
            Assert.Equal(produtosDtoUpdate.DataValidade, resultValue.DataValidade);
            Assert.Equal(produtosDtoUpdate.CodigoFornecedor, resultValue.CodigoFornecedor);
            Assert.Equal(produtosDtoUpdate.DescricaoFornecedor, resultValue.DescricaoFornecedor);
            Assert.Equal(produtosDtoUpdate.CnpjFornecedor, resultValue.CnpjFornecedor);
        }
    }
}
