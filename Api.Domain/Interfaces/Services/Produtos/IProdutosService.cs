using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Produtos;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Produtos
{
    public interface IProdutosService
    {
        Task<ProdutosDto> Get(int id);
        Task<IEnumerable<ProdutosDto>> GetAll(int numeroPagina, int quantidadeRegistros);
        Task<ProdutosDtoCreateResult> Post(ProdutosDtoCreate produtos);
        Task<ProdutosDtoUpdateResult> Put(ProdutosDtoUpdate produtos);
        Task<bool> Delete(int id);
    }
}
