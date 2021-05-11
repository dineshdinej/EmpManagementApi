using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpManagementApi.Models;


namespace EmpManagementApi.Interface
{
   public interface IEmployee : IDisposable
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(int Employeeid);

        string EmployeeStatus(int Employeeid);

        IEnumerable<Employee> EmployeeSearch(int? Employeeid, string department,string firstName,string LastName);
        void AddEmployee(Employee item);
        void UpdateEmployee(Employee item, int Employeeid);
        void DeleteEmployee(int Employeeid);
    }
}
