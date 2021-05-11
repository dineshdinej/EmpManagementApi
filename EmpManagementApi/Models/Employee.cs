using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmpManagementApi.Models
{

    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext() : base("EmpDBConnection") { }
        public DbSet<Employee> employees { get; set; }
        public DbSet<ErrorLog> errorLogs { get; set; }
    }

    [Table("Employee")]
    public class Employee
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailId { get; set; }
        public int? DepartmentId { get; set; }
        public int? ManagerId { get; set; }
       

    }
}