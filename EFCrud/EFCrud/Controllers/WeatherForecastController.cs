using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCrud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly MyDBContext dbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, MyDBContext context)
        {
            _logger = logger;
            this.dbContext = context;
        }

        [HttpGet]
        public List<Employee> Get()
        {
            return dbContext.Employees.ToList();
        }

        [HttpPost]
        public bool Post( [FromBody] Employee newEmployee)
        {
            var newEmp = new Employee();
            newEmp.FirstName = newEmployee.FirstName;
            dbContext.Employees.Add(newEmp);
            dbContext.SaveChanges();
            return true;
        }

        [HttpDelete]
        public bool Delete([FromBody] int deleteId)
        {
            var foundEmployee = dbContext.Employees.Find(deleteId);
            dbContext.Employees.Remove(foundEmployee);
            dbContext.SaveChanges();
            return true;
        }
    }
}
