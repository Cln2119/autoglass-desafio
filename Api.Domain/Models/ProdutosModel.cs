using System;

namespace Api.Domain.Models
{
    public class ProdutosModel : BaseModel
    {     
        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        private string _situacao;
        public string Situacao
        {
            get { return _situacao; }
            set { _situacao = value; }
        }

        private string _dataFabricacao;
        public string DataFabricacao
        {
            get { return _dataFabricacao; }
            set { _dataFabricacao = value; }
        }

        private string _dataValidade;
        public string DataValidade
        {
            get { return _dataValidade; }
            set { _dataValidade = value; }
        }

        private string _codigoFornecedor;
        public string CodigoFornecedor
        {
            get { return _codigoFornecedor; }
            set { _codigoFornecedor = value; }
        }

        private string _descricaoFornecedor;
        public string DescricaoFornecedor
        {
            get { return _descricaoFornecedor; }
            set { _descricaoFornecedor = value; }
        }

        private string _cnpjFornecedor;
        public string CnpjFornecedor
        {
            get { return _cnpjFornecedor; }
            set { _cnpjFornecedor = value; }
        }

    }
}
