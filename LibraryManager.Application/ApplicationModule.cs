using LibraryManager.Application.Commands.LoanCommands.InsertLoan;
using LibraryManager.Application.Models;
using MediatR;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using LibraryManager.Application.Commands.BookCommands.InsertBook;

namespace LibraryManager.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddHandlers()
                .AddValidation();
            return services;
        }
       

        private static IServiceCollection AddHandlers(this IServiceCollection services) 
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertLoanCommand>());

            services.AddTransient<IPipelineBehavior<InsertLoanCommand, ResultViewModel<int>>, ValidateInsertLoanCommandBehavior>();

            return services;
        }

        private static  IServiceCollection AddValidation(this IServiceCollection services)
        {

            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<InsertBookCommand>();

            return services;
        }

    }
}
