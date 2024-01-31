using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Produtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Produtos;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class ProdutosService : IProdutosService
    {
        private IRepository<ProdutosEntity> _repository;
        private readonly IMapper _mapper;

        public ProdutosService(IRepository<ProdutosEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ProdutosDto> Get(int id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<ProdutosDto>(entity);
        }

        public async Task<IEnumerable<ProdutosDto>> GetAll(int numeroPagina, int quantidadeRegistros)
        {
            var listEntity = await _repository.SelectAsync();    
            var produtosPaginados = listEntity.Skip((numeroPagina - 1) * quantidadeRegistros).Take(quantidadeRegistros);
            if(numeroPagina == 0|| quantidadeRegistros == 0)
                return _mapper.Map<IEnumerable<ProdutosDto>>(listEntity);
            else
                return _mapper.Map<IEnumerable<ProdutosDto>>(produtosPaginados);
        }

        public async Task<ProdutosDtoCreateResult> Post(ProdutosDtoCreate produtos)
        {
            var model = _mapper.Map<ProdutosModel>(produtos);
            var entity = _mapper.Map<ProdutosEntity>(model);
            entity.DataCriacao = DateTime.Now;
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<ProdutosDtoCreateResult>(result);
        }

        public async Task<ProdutosDtoUpdateResult> Put(ProdutosDtoUpdate produtos)
        {
            var model = _mapper.Map<ProdutosModel>(produtos);
            var entity = _mapper.Map<ProdutosEntity>(model);

            var retornoRegistro = await _repository.SelectAsync();
            
            if (retornoRegistro == null)
                return null;

            var registroExiste = retornoRegistro.Any(produto => produto.Id == produtos.Id);

            if (registroExiste)
            {
                var selecionaRegistro = retornoRegistro.Where(produto => produto.Id == produtos.Id).First();

                entity.DataCriacao = selecionaRegistro.DataCriacao;
                entity.DataAtualizacao = DateTime.Now;

                var result = await _repository.UpdateAsync(entity);
                return _mapper.Map<ProdutosDtoUpdateResult>(result);
            }

            return null;
               
        }
    }
}
