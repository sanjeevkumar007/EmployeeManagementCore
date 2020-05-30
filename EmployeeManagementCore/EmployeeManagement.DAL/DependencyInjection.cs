
using EmployeeManagement.DAL.DataAccessRepository;
using EmployeeManagement.DAL.DBAccess;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManagement.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeDataAccess, EmployeeDataAccess>().AddSingleton<ISQLDataAccess,SQLDataAccess>();
            return services;
        }
    }
}
