using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Produtos;
using Api.Domain.Interfaces.Services.Produtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarGetAll
{
    public class Retorno_GetAll
    {
        private ProdutosController _controller;

        [Fact(DisplayName = "É possível Realizar o Get All.")]
        public async Task E_Possivel_Invocar_a_Controller_GetAll()
        {
            int numeroPagina = 1;
            int quantidadeRegistros = 1;
            var serviceMock = new Mock<IProdutosService>();
            serviceMock.Setup(m => m.GetAll(numeroPagina, quantidadeRegistros)).ReturnsAsync(
                 new List<ProdutosDto>
                 {
                    new ProdutosDto
                    {
                        Id = 1,
                        Descricao = "Vidro",
                        Situacao = "Ativo",
                        DataFabricacao = "2024-01-29",
                        DataValidade = "2025-01-29",
                        CodigoFornecedor = "123456",
                        DescricaoFornecedor = "Fornecedor Vidros",
                        CnpjFornecedor = "00.000.000/0001-01",
                        DataCriacao = DateTime.UtcNow
                    },
                    new ProdutosDto
                    {
                        Id = 1,
                        Descricao = "Vidro",
                        Situacao = "Ativo",
                        DataFabricacao = "2024-01-29",
                        DataValidade = "2025-01-29",
                        CodigoFornecedor = "123456",
                        DescricaoFornecedor = "Fornecedor Vidros",
                        CnpjFornecedor = "00.000.000/0001-01",
                        DataCriacao = DateTime.UtcNow
                    }
                 }
            );
            _controller = new ProdutosController(serviceMock.Object);
            var result = await _controller.RecuperarTodos(numeroPagina, quantidadeRegistros);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as IEnumerable<ProdutosDto>;
            Assert.True(resultValue.Count() == 2);
        }
    }
}
