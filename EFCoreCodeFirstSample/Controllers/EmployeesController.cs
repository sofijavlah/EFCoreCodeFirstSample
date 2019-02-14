using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreCodeFirstSample.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreCodeFirstSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeesController(EmployeeContext context)
        {
            _context = context;

            //if (_context.Employees.Count() == 0)
            //{
            //    _context.Employees.Add(new Employee() { FirstName = "Cao" });
            //    _context.SaveChanges();
            //}
        }

        // GET: api/Employees
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public IActionResult GetEmployee(long id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public IActionResult PutEmployee(long id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            var e = _context.Employees.Find(id);
            if (e != null)
            {
                e.FirstName = employee.FirstName;
                e.LastName = employee.LastName;
                e.DateOfBirth = employee.DateOfBirth;
                e.Email = employee.Email;
                e.PhoneNumber = employee.PhoneNumber;

                _context.SaveChanges();
                return Ok();
            }

            return NoContent();
        }

        // POST: api/Employees
        [HttpPost]
        public IActionResult PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return Ok(employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(long id)
        {
            var e = _context.Employees.Find(id);
            if (e == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(e);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
