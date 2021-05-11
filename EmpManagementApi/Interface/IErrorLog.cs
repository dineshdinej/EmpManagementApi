using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpManagementApi.Models;


namespace EmpManagementApi.Interface
{
   public interface IErrorLog : IDisposable
    {        
       
        void AddErrorLog(ErrorLog Log);
        
    }
}
