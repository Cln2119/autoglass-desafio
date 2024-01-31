using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Produtos;
using Api.Domain.Interfaces.Services.Produtos;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoGetAll : ProdutosTestes
    {
        private IProdutosService _service;
        private Mock<IProdutosService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GETAll.")]
        public async Task E_Possivel_Executar_Metodo_GetAll()
        {
            int numeroPagina = 1;
            int quantidadeRegistros = 1;
            _serviceMock = new Mock<IProdutosService>();
            _serviceMock.Setup(m => m.GetAll(numeroPagina, quantidadeRegistros)).ReturnsAsync(listaProdutosDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll(numeroPagina, quantidadeRegistros);
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<ProdutosDto>();
            _serviceMock = new Mock<IProdutosService>();
            _serviceMock.Setup(m => m.GetAll(numeroPagina, quantidadeRegistros)).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll(numeroPagina, quantidadeRegistros);
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}
