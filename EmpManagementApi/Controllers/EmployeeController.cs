using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmpManagementApi.Models;
using EmpManagementApi.Interface;
using EmpManagementApi.Common;

namespace EmpManagementApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployee _employee;
        private readonly IErrorLog _errorLog;
         

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
          
        }
        public EmployeeController(IErrorLog errorlog)
        {
            _errorLog = errorlog;

        }


        [HttpGet]
        public Employee GetEmployee(int id)
        {
            return _employee.GetEmployeeById(id);
        }

        [HttpPost]
        public IHttpActionResult AddEmployee(Employee employee)
        {
            _employee.AddEmployee(employee);
            
            
            //sending mail while creating user
            Common.BAL.SendMail(employee.EmailId, "hr@gmail.com", "Employee Registration", "Welcome to our company");
            return Ok(new { message = "Employee is added successfully." });
        }


        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                return _employee.GetEmployees().OrderBy(x => x.FirstName).ToList();
            }
            catch (Exception ex)
            {
                _errorLog.AddErrorLog(new ErrorLog { LogDate = DateTime.Now, LogDescription = ex.StackTrace.ToString(), ErroLogPage = "GetEmployees" });
                return null;
            }


        }
        [HttpPut]
        public IHttpActionResult UpdateEmployee(Employee employee, int employeeid)
        {
            _employee.UpdateEmployee(employee, employeeid);
            return Ok(new { message = "Employee is updated successfully." });
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            _employee.DeleteEmployee(id);
            //sending mail while deleting user
            Common.BAL.SendMail("hr@gmail.com","", "Employee Deleted", "Employee has been deleted.");
            return Ok(new { message = "Employee is deleted successfully." });
        }

        [HttpGet]
        public IHttpActionResult Search(int? employeeId, string department, string firstName, string LastName)
        {
            try
            {
                var result = _employee.EmployeeSearch(employeeId, department, firstName, LastName);

                if (result !=null)
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _errorLog.AddErrorLog(new ErrorLog { LogDate = DateTime.Now, LogDescription = ex.StackTrace.ToString(), ErroLogPage = "GetEmployees" });
                return null;
            }
        }

        [HttpGet]
        public IHttpActionResult GetEmployeeStatus(int employeeId)
        {
            try
            {
                var result = _employee.EmployeeStatus(employeeId);

                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _errorLog.AddErrorLog(new ErrorLog { LogDate = DateTime.Now, LogDescription = ex.StackTrace.ToString(), ErroLogPage = "GetEmployeeStatus" });
                return null;
            }
        }
    }
}
