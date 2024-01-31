namespace Api.Domain.Entities {
    public class ProdutosEntity : BaseEntity {
        public string Descricao { get; set; }
        public string Situacao { get; set; }
        public string DataFabricacao { get; set; }
        public string DataValidade { get; set; }
        public string CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CnpjFornecedor { get; set; }
    }
}
