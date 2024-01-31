using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Produtos;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoDelete : ProdutosTestes
    {
        private IProdutosService _service;
        private Mock<IProdutosService> _serviceMock;
        [Fact(DisplayName = "É possível executar método Delete.")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<IProdutosService>();
            _serviceMock.Setup(m => m.Delete(IdProduto))
                        .ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(IdProduto);
            Assert.True(deletado);

            _serviceMock = new Mock<IProdutosService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<int>()))
                        .ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(It.IsAny<int>());
            Assert.False(deletado);

        }
    }
}
