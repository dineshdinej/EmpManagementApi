using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmpManagementApi.Models;
using EmpManagementApi.Interface;


namespace EmpManagementApi.Services
{
   
    public class ErrorLogSevice : IErrorLog
    {

        private EmployeeDBContext db = new EmployeeDBContext();
        public void AddErrorLog(ErrorLog errorLog)
        {

            try
            {
                db.errorLogs.Add(new ErrorLog
                {
                   
                   
                    LogDescription = errorLog.LogDescription,
                    LogDate = errorLog.LogDate,
                    ErroLogPage=errorLog.ErroLogPage


                });
                db.SaveChanges();
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
