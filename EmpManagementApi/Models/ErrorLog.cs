using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmpManagementApi.Models
{

 

    [Table("ErrorLog")]
    public class ErrorLog
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ErrorLogId { get; set; }
        public string LogDescription { get; set; }
        public string ErroLogPage { get; set; }
        public DateTime LogDate { get; set; }


    }
}