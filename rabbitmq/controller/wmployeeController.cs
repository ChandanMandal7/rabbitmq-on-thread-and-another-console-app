using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace rabbitmq.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private List<string> employees;

        public EmployeeController()
        {
            employees = new List<string>();
            employees.Add("rajan");
            employees.Add("chandan");
            employees.Add("aditiya");
            employees.Add("jayKumar");
        }

        [HttpGet]
        public List<string> GetEmployees()
        {
            return employees;
        }
    }
}
