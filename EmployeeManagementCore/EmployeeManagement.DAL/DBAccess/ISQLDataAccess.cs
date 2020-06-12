using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DAL.DBAccess
{
    public interface ISQLDataAccess
    {
        Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters);
        Task<int> ExecuteData<T>(string storedProcedure, T paramters);
        Task<int> RemoveData<T>(string storedProcedure, T paramters);

    }
}
