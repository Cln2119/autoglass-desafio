using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        private DateTime? _dataCriacao;
        public DateTime? DataCriacao
        {
            get { return _dataCriacao; }
            set { _dataCriacao = (value == null ? DateTime.UtcNow : value); }
        }

        public DateTime? DataAtualizacao { get; set; }

    }
}
