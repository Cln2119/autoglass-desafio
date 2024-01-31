using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Produtos;
using Api.Domain.Interfaces.Services.Produtos;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoGet : ProdutosTestes
    {
        private IProdutosService _service;
        private Mock<IProdutosService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GET.")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IProdutosService>();
            _serviceMock.Setup(m => m.Get(IdProduto)).ReturnsAsync(produtosDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdProduto);
            Assert.NotNull(result);
            Assert.True(result.Id == IdProduto);
            Assert.Equal(DescricaoProduto, result.Descricao);
            Assert.Equal(SituacaoProduto, result.Situacao);
            Assert.Equal(DataFabricacaoProduto, result.DataFabricacao);
            Assert.Equal(DataValidadeProduto, result.DataValidade);
            Assert.Equal(CodigoFornecedorProduto, result.CodigoFornecedor);
            Assert.Equal(DescricaoFornecedorProduto, result.DescricaoFornecedor);
            Assert.Equal(CnpjFornecedorProduto, result.CnpjFornecedor);


            _serviceMock = new Mock<IProdutosService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<int>())).Returns(Task.FromResult((ProdutosDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(IdProduto);
            Assert.Null(_record);

        }
    }
}
