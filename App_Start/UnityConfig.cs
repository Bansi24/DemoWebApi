using ApiShared.Assemblers;
using ApiShared.Assemblers.Interfaces;
using ApiShared.Services;
using ApiShared.Services.Interface;
using DemoWebApi.Models;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace DemoWebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IEmployeeAssembler, EmployeeAssembler>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
        }
    }
}