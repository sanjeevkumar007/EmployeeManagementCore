using Dapper;
using EmployeesManagement.DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace EmployeeManagement.DAL.DBAccess
{
    public class SQLDataAccess : ISQLDataAccess
    {
        public IConfiguration Configuration { get; }


        public string GetConnectionString(string name)
        {
            //AppConfiguration configuration = new AppConfiguration();
            var conStr = ConnectionConfiguration.ConnectionString;
            return conStr;
        }
        public async Task<List<T>> LoadData<T,U>(string storedProcedure,U parameters,string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using (IDbConnection connection=new SqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return rows.ToList();
            }
        }

        public async Task<int> ExecuteData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            int result = 0;
            try
            {
                string connectionString = GetConnectionString(connectionStringName);
                using (IDbConnection _connection = new SqlConnection(connectionString))
                {
                    result = await _connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }

        public async Task<int> UpdateData<T>(string storedProcedure,T parameters,string connectionStringName)
        {
            int result = 0;
            try
            {
                string connectionString = GetConnectionString(connectionStringName);

                using (IDbConnection _connection = new SqlConnection(connectionString))
                {
                     result = await _connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch (Exception)
            {

                result=1;
            }

            return result;
        }

        public async Task<int> RemoveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            int result = 0;
            try
            {

                string connectionString = GetConnectionString(connectionStringName);

                using (IDbConnection _connection = new SqlConnection(connectionString))
                {
                    result = await _connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch (Exception)
            {

                result = -1;

            }

            return result;
        }

       
    }
}
