using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class ProdutosImplementation : BaseRepository<ProdutosEntity>, IProdutosRepository
    {
        private DbSet<ProdutosEntity> _dataset;
        public ProdutosImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<ProdutosEntity>();
        }     
    }
}
