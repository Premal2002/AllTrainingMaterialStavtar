using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem_InMemory_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        Employee employee = new Employee();//this is bad and old fashioned use DI instead

        [HttpGet("/employees/list")]
        public IActionResult GetAllEmployees()
        {
            var data = employee.AllEmployees();
            return Ok(data);
        }

        [HttpGet("/employees/id/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var data = employee.EmployeeById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpGet("/employees/designation/{designation}")]
        public IActionResult GetEmployeesByDesignation(string designation)
        {
            try
            {
                var data = employee.EmployeesByDesignation(designation);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/employees/city/{city}")]
        public IActionResult GetEmployeesByCity(string city)
        {
            try
            {
                var data = employee.EmployeesByCity(city);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/employees/empCount")]
        public IActionResult GetEmployeesCount()
        {
            var data = employee.TotalEmployeeCount();
            return Ok(data);
        }

        [HttpPost("/employees/add")]
        public IActionResult AddEmployee([FromBody] Employee emp)
        {
            try
            {
                string msg = employee.AddEmployee(emp);
                return Created("", msg);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/employee/delete/{id}")]
        public IActionResult DeleteEmp(int id)
        {
            try
            {
                var msg = employee.DeleteEmployee(id);
                return Accepted(msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/employees/edit")]
        public IActionResult ModifyEmployee([FromBody] Employee emp)
        {
            try
            {
                var msg = employee.ModifyEmployee(emp);
                return Accepted(msg);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

