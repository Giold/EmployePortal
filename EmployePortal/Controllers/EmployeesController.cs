using EmployePortal.Datos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployePortal.Controllers
{
    // localhost:xxxx/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ContextoDBAplicacion contextoDB;

        public EmployeesController(ContextoDBAplicacion contextoDB)
        {
            this.contextoDB = contextoDB;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(contextoDB.Employees.ToList());
        }

        [HttpPut]
        public IActionResult AddEmployee()
        {


        }
    }
}
