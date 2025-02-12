using EmployePortal.Datos;
using EmployePortal.Modelos;
using EmployePortal.Modelos.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeId(Guid id) 
        {
            var employee = contextoDB.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
        

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };

            contextoDB.Employees.Add(employeeEntity);
            contextoDB.SaveChanges();

            return Ok(employeeEntity);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = contextoDB.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }

            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;

            contextoDB.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = contextoDB.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }

            contextoDB.Employees.Remove(employee);
            contextoDB.SaveChanges();
            return Ok();
        }

    }
}
