using AutoMapper;
using Employee.ServiceModels;
using Employee.Services;
using Employee.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Employee.Web.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController
            (
                IEmployeeService employeeService,
                IMapper mapper
            ) : base(mapper)
        {
            _employeeService = employeeService;
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            return await ResponceAsync(() => _employeeService.GetAllAsync());
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployee(int employeeId)
        {
            return await ResponceAsync(() => _employeeService.GetByIdAsync(employeeId));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeViewModel employee)
        {
            return await ResponceAsync(() => _employeeService.CreateAsync(mapper.Map<EmployeeServiceModel>(employee)));
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeViewModel employee)
        {
            return await ResponceAsync(() => _employeeService.UpdateAsync(mapper.Map<EmployeeServiceModel>(employee)));
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> Delete(int employeeId)
        {
            return await ResponceAsync(() => _employeeService.DeleteAsync(employeeId));
        }
    }
}
