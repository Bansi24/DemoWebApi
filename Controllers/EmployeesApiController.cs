using ApiShared.Services.Interface;
using ApiShared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace DemoWebApi.Controllers
{
    public class EmployeesApiController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        
        public EmployeesApiController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("api/Employees/Get")]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _employeeService.GetEmployees();
        }

        [HttpPost]
        [Route("api/Employees/Create")]
        public async Task CreateAsync([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.Add(employee);
            }
        }

        [HttpGet]
        [Route("api/Employees/Details/{id}")]
        public async Task<Employee> Details(string id)
        {
            var result = await _employeeService.GetEmployee(id);
            return result;
        }

        [HttpPut]
        [Route("api/Employees/Edit")]
        public async Task EditAsync([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.Update(employee);
            }
        }

        [HttpDelete]
        [Route("api/Employees/Delete/{id}")]
        public async Task DeleteConfirmedAsync(string id)
        {
            await _employeeService.Delete(id);
        }
    }
}
