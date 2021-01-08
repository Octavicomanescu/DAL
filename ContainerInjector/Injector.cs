using BankSimAPI.Data;
using DAL;
using DAL.Data;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ContainerInjector {
    public class Injector {

        public static void InjectRepositories(IServiceCollection services) {
            services.AddTransient<IBankOperationsRepository,BankOperationsRepository>();
            services.AddTransient<ILoansOperationsRepository,LoansOperationsRepository>();
            services.AddTransient<DebtRepository>();
        }

    }
}
