using LibraryManager.Application.Commands.LoanCommands.InsertLoan;
using LibraryManager.Application.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddHandlers();
            return services;
        }
       

        private static IServiceCollection AddHandlers(this IServiceCollection services) 
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertLoanCommand>());

            services.AddTransient<IPipelineBehavior<InsertLoanCommand, ResultViewModel<int>>, ValidateInsertLoanCommandBehavior>();

            return services;
        }

    }
}
