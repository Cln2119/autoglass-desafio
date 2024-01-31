using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Produtos;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoCreate : ProdutosTestes
    {
        private IProdutosService _service;
        private Mock<IProdutosService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Create.")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<IProdutosService>();
            _serviceMock.Setup(m => m.Post(produtosDtoCreate)).ReturnsAsync(produtosDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(produtosDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(DescricaoProduto, result.Descricao);
            Assert.Equal(SituacaoProduto, result.Situacao);
            Assert.Equal(DataFabricacaoProduto, result.DataFabricacao);
            Assert.Equal(DataValidadeProduto, result.DataValidade);
            Assert.Equal(CodigoFornecedorProduto, result.CodigoFornecedor);
            Assert.Equal(DescricaoFornecedorProduto, result.DescricaoFornecedor);
            Assert.Equal(CnpjFornecedorProduto, result.CnpjFornecedor);
        }
    }
}
