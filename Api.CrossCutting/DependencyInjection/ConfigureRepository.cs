using System;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IProdutosRepository, ProdutosImplementation>();

            serviceCollection.AddDbContext<MyContext>(
                      options => options.UseSqlServer("Data Source=DESKTOP-QB722AQ\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True")
                  );
        }
    }
}
