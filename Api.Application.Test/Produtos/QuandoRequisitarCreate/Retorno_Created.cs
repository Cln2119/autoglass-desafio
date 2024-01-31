using System;
using System.Globalization;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Produtos;
using Api.Domain.Interfaces.Services.Produtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarCreate
{
    public class Retorno_Created
    {
        private ProdutosController _controller;
        [Fact(DisplayName = "É possível Realizar o Created.")]
        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<IProdutosService>();
            var descricao = "Vidro";
            var situacao = "Ativo";
            var dataFabricacao = "2024-01-29";
            var dataValidade = "2025-01-29";
            var codigoFornecedor = "123456";
            var descricaoFornecedor = "Fornecedor Vidros";
            var cnpjFornecedor = "00.000.000/0001-01";

            string formato = "yyyy-MM-dd";
            DateTime dataFabricacaoFormatado = DateTime.ParseExact(dataFabricacao, formato, CultureInfo.InvariantCulture);
            DateTime dataValidadeFormatado = DateTime.ParseExact(dataValidade, formato, CultureInfo.InvariantCulture);

            if (dataFabricacaoFormatado >= dataValidadeFormatado)
            {
                _controller = new ProdutosController(serviceMock.Object);
                _controller.ModelState.AddModelError("DataFabricacao", "O valor da data de fabricação não pode ser maior que a data de validade");
            }    

            serviceMock.Setup(m => m.Post(It.IsAny<ProdutosDtoCreate>())).ReturnsAsync(
                new ProdutosDtoCreateResult
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

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var produtosDtoCreate = new ProdutosDtoCreate
            {
                Descricao = descricao,
                Situacao = situacao,
                DataFabricacao = dataFabricacao,
                DataValidade = dataValidade,
                CodigoFornecedor = codigoFornecedor,
                DescricaoFornecedor = descricaoFornecedor,
                CnpjFornecedor = cnpjFornecedor,
            };

            var result = await _controller.Inserir(produtosDtoCreate);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as ProdutosDtoCreateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(produtosDtoCreate.Descricao, resultValue.Descricao);
            Assert.Equal(produtosDtoCreate.Situacao, resultValue.Situacao);
            Assert.Equal(produtosDtoCreate.DataFabricacao, resultValue.DataFabricacao);
            Assert.Equal(produtosDtoCreate.DataValidade, resultValue.DataValidade);
            Assert.Equal(produtosDtoCreate.CodigoFornecedor, resultValue.CodigoFornecedor);
            Assert.Equal(produtosDtoCreate.DescricaoFornecedor, resultValue.DescricaoFornecedor);
            Assert.Equal(produtosDtoCreate.CnpjFornecedor, resultValue.CnpjFornecedor);


        }
    }
}
