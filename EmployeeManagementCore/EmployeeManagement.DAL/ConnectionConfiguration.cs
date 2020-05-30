using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EmployeesManagement.DAL
{
    public class ConnectionConfiguration
    {
        public static  string _connectionString = string.Empty;

        public ConnectionConfiguration()
        {

         

        }

    
        public static string ConnectionString
        {
            get
            {
                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                configurationBuilder.AddJsonFile(path, false);
               
                var root = configurationBuilder.Build();

                _connectionString = root.GetSection("ConnectionString").GetSection("EmployeeConnectionString").Value;

                var appSetting = root.GetSection("ApplicationSettings");

                
                return _connectionString;
            }
        }

    }
}
