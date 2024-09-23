﻿using LibraryManager.Application.Commands.LoanCommands.InsertLoan;
using LibraryManager.Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddHandlers();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services) 
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services) 
        {
        services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertLoanCommand>());  

            return services;
        }

    }
}
