using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmpManagementApi.Models;
using EmpManagementApi.Interface;


namespace EmpManagementApi.Services
{

    public class EmployeeService : IEmployee
    {

        private EmployeeDBContext db = new EmployeeDBContext();
        public void AddEmployee(Employee item)
        {

            try
            {
                db.employees.Add(new Employee
                {

                    EmailId = item.EmailId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,


                });
                db.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
        }


        public void DeleteEmployee(int id)
        {
            try
            {
                Employee emp = db.employees.Find(id);
                if (emp != null)
                {
                    db.employees.Remove(emp);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Employee GetEmployeeById(int id)
        {
            var getarticle = db.employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            return getarticle;
        }

        public IEnumerable<Employee> EmployeeSearch(int? Employeeid, string department, string firstName, string LastName)
        {
            var employee = db.employees.Where(x => x.EmployeeId == Employeeid || x.FirstName == firstName || x.LastName == LastName).ToList().OrderBy(x => x.FirstName);
            return employee;
        }

        public string EmployeeStatus(int Employeeid)
        {

            IEnumerable<Employee> employees = db.employees.Where(x => x.ManagerId == Employeeid).ToList();
            Employee employee = db.employees.Where(x => x.EmployeeId == Employeeid).FirstOrDefault();
            return GetEmployeeDesignation(employee, employees);
        }

        private static string GetEmployeeDesignation(Employee employee, IEnumerable<Employee> employees)
        {
            if (!employee.ManagerId.HasValue)
            {
                return "Head";
            }

            if (!employees.Any(m => m.ManagerId == employee.EmployeeId))
            {
                return "Associate";
            }

            return "Manager";
        }


        public IEnumerable<Employee> GetEmployees()
        {
            var getarticle = db.employees.ToList();
            return getarticle;
        }


        public void UpdateEmployee(Employee item, int employeeid)
        {
            var emp = db.employees.Where(x => x.EmployeeId == employeeid).FirstOrDefault();
            try
            {
                if (emp != null)
                {
                    emp.FirstName = item.FirstName;
                    emp.EmailId = item.EmailId;
                    emp.LastName = item.LastName;
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }


        #region IDisposable Support 
        private bool disposedValue = false; // To detect redundant calls   

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects). 
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below. 

                // TODO: set large fields to null. 
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources. 
        // ~ArticleService() 
        // { 
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above. 
        //   Dispose(false); 
        // }   

        // This code added to correctly implement the disposable pattern. 
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above. 
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above. 
            // GC.SuppressFinalize(this); 
        }
        #endregion
    }
}
