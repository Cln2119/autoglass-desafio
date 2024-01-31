using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Produtos;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoUpdate : ProdutosTestes
    {
        private IProdutosService _service;
        private Mock<IProdutosService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Update.")]
        public async Task E_Possivel_Executar_Metodo_Update()
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

            _serviceMock = new Mock<IProdutosService>();
            _serviceMock.Setup(m => m.Put(produtosDtoUpdate)).ReturnsAsync(produtosDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(produtosDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(DescricaoProdutoAlterado, resultUpdate.Descricao);
            Assert.Equal(SituacaoProdutoAlterado, resultUpdate.Situacao);
            Assert.Equal(DataFabricacaoProdutoAlterado, resultUpdate.DataFabricacao);
            Assert.Equal(DataValidadeProdutoAlterado, resultUpdate.DataValidade);
            Assert.Equal(CodigoFornecedorProdutoAlterado, resultUpdate.CodigoFornecedor);
            Assert.Equal(DescricaoFornecedorProdutoAlterado, resultUpdate.DescricaoFornecedor);
            Assert.Equal(CnpjFornecedorProdutoAlterado, resultUpdate.CnpjFornecedor);

        }
    }
}
