using LibraryManager.Core.Repositories;
using LibraryManager.Infrastructure.Persistance;
using LibraryManager.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services
                .AddRepositories()
                .AddData(configuration);

            return services;
        }

        private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("LibraryManagerCs");
            services.AddDbContext<LibraryManagerDbContext>(o => o.UseSqlServer(connectionString));

            return services;

        }

        private static IServiceCollection AddRepositories(this IServiceCollection services) 
        {
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
