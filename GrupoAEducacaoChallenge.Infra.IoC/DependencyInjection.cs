using GrupoAEducacaoChallenge.Application.Interfaces;
using GrupoAEducacaoChallenge.Application.Mappings;
using GrupoAEducacaoChallenge.Application.Services;
using GrupoAEducacaoChallenge.Domain;
using GrupoAEducacaoChallenge.Infra.Data.Context;
using GrupoAEducacaoChallenge.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace GrupoAEducacaoChallenge.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("DefaultMysqlConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAlunoService, AlunoService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
