using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Produtos;

namespace Api.Service.Test.Usuario
{
    public class ProdutosTestes
    {       
        public static string DescricaoProduto { get; set; }
        public static string SituacaoProduto { get; set; }
        public static string DataFabricacaoProduto { get; set; }
        public static string DataValidadeProduto { get; set; }
        public static string CodigoFornecedorProduto { get; set; }
        public static string DescricaoFornecedorProduto { get; set; }
        public static string CnpjFornecedorProduto { get; set; }

        public static string DescricaoProdutoAlterado { get; set; }
        public static string SituacaoProdutoAlterado { get; set; }
        public static string DataFabricacaoProdutoAlterado { get; set; }
        public static string DataValidadeProdutoAlterado { get; set; }
        public static string CodigoFornecedorProdutoAlterado { get; set; }
        public static string DescricaoFornecedorProdutoAlterado { get; set; }
        public static string CnpjFornecedorProdutoAlterado { get; set; }
        public static int IdProduto { get; set; }

        public List<ProdutosDto> listaProdutosDto = new List<ProdutosDto>();
        public ProdutosDto produtosDto;
        public ProdutosDtoCreate produtosDtoCreate;
        public ProdutosDtoCreateResult produtosDtoCreateResult;
        public ProdutosDtoUpdate produtosDtoUpdate;
        public ProdutosDtoUpdateResult produtosDtoUpdateResult;

        public ProdutosTestes()
        {
            IdProduto = 1;
            DescricaoProdutoAlterado = "Vidro 2";
            SituacaoProdutoAlterado = "Inativo";
            DataFabricacaoProdutoAlterado = "2024-01-30";
            DataValidadeProdutoAlterado = "2025-01-30";
            CodigoFornecedorProdutoAlterado = "123458";
            DescricaoFornecedorProdutoAlterado = "Fornecedor Vidros 2";
            CnpjFornecedorProdutoAlterado = "00.000.000/0002-02";

            for (int i = 0; i < 10; i++)
            {
                var dto = new ProdutosDto()
                {
                    Id = 1,
                    Descricao = "Vidro",
                    Situacao = "Ativo",
                    DataFabricacao = "2024-01-29",
                    DataValidade = "2025-01-29",
                    CodigoFornecedor = "123456",
                    DescricaoFornecedor = "Fornecedor Vidros",
                    CnpjFornecedor = "00.000.000/0001-01",
                };
                listaProdutosDto.Add(dto);
            }

            produtosDto = new ProdutosDto
            {
                Id = IdProduto,
                Descricao = DescricaoProduto,
                Situacao = SituacaoProduto,
                DataFabricacao = DataFabricacaoProduto,
                DataValidade = DataValidadeProduto,
                CodigoFornecedor = CodigoFornecedorProduto,
                DescricaoFornecedor = DescricaoFornecedorProduto,
                CnpjFornecedor = CnpjFornecedorProduto
            };

            produtosDtoCreate = new ProdutosDtoCreate
            {
                Descricao = DescricaoProduto,
                Situacao = SituacaoProduto,
                DataFabricacao = DataFabricacaoProduto,
                DataValidade = DataValidadeProduto,
                CodigoFornecedor = CodigoFornecedorProduto,
                DescricaoFornecedor = DescricaoFornecedorProduto,
                CnpjFornecedor = CnpjFornecedorProduto,
            };


            produtosDtoCreateResult = new ProdutosDtoCreateResult
            {
                Id = IdProduto,
                Descricao = DescricaoProduto,
                Situacao = SituacaoProduto,
                DataFabricacao = DataFabricacaoProduto,
                DataValidade = DataValidadeProduto,
                CodigoFornecedor = CodigoFornecedorProduto,
                DescricaoFornecedor = DescricaoFornecedorProduto,
                CnpjFornecedor = CnpjFornecedorProduto,
                DataCriacao = DateTime.UtcNow
            };

            produtosDtoUpdate = new ProdutosDtoUpdate
            {
                Id = IdProduto,
                Descricao = DescricaoProdutoAlterado,
                Situacao = SituacaoProdutoAlterado,
                DataFabricacao = DataFabricacaoProdutoAlterado,
                DataValidade = DataValidadeProdutoAlterado,
                CodigoFornecedor = CodigoFornecedorProdutoAlterado,
                DescricaoFornecedor = DescricaoFornecedorProdutoAlterado,
                CnpjFornecedor = CnpjFornecedorProdutoAlterado,
            };

            produtosDtoUpdateResult = new ProdutosDtoUpdateResult
            {
                Id = IdProduto,
                Descricao = DescricaoProdutoAlterado,
                Situacao = SituacaoProdutoAlterado,
                DataFabricacao = DataFabricacaoProdutoAlterado,
                DataValidade = DataValidadeProdutoAlterado,
                CodigoFornecedor = CodigoFornecedorProdutoAlterado,
                DescricaoFornecedor = DescricaoFornecedorProdutoAlterado,
                CnpjFornecedor = CnpjFornecedorProdutoAlterado,
                DataCriacao = DateTime.UtcNow
            };

        }
    }
}
