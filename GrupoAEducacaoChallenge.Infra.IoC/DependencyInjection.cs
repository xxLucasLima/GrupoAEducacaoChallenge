using GrupoAEducacaoChallenge.Domain;
using GrupoAEducacaoChallenge.Infra.Data.Context;
using GrupoAEducacaoChallenge.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoAEducacaoChallenge.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IAlunoRepository, AlunoRepository>();

            return services;
        }
    }
}
