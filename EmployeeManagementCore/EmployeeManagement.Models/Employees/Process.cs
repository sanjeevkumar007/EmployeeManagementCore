using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Models.Employees
{
    public class Process
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
