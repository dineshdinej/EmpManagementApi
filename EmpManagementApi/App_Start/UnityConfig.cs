using System.Web.Http;
using Unity;
using Unity.WebApi;
using EmpManagementApi.Interface;
using EmpManagementApi.Services;

namespace EmpManagementApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            
            container.RegisterType<IEmployee, EmployeeService>();
            

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}