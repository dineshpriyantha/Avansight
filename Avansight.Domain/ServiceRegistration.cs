using Avansight.Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avansight.Domain
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IPatientRepository, PatientService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
