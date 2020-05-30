using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DAL.DBAccess
{
    public interface ISQLDataAccess
    {
       Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);

        Task<int> ExecuteData<T>(string storedProcedure, T paramters, string connectionStringName);
        Task<int> RemoveData<T>(string storedProcedure, T paramters, string connectionStringName);

    }
}
