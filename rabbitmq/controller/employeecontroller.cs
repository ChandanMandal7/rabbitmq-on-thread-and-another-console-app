using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rabbitmq.models;
using rabbitmq.Service;

namespace rabbitmq.controller
{
  [ApiController]
  [Route("[controller]")]
  public class employeecontroller : ControllerBase
  {
    private readonly ILogger<employeecontroller> _logger;
    private readonly Iemployee _employees;


    //In-Memory
    public static readonly List<EmplyeeModel> empList = new();

    public employeecontroller(ILogger<employeecontroller> logger, Iemployee employees)
    {
      this._logger = logger;
      this._employees = employees;
    }




    [HttpPost]
    public IActionResult CreateEmployee(EmplyeeModel newemplyeeModel)
    {

      if (!ModelState.IsValid)
      {
        return BadRequest("Invalid data");
      }
      empList.Add(newemplyeeModel);

      _employees.PostEmploye<EmplyeeModel>(newemplyeeModel);
      return Ok("Employee Added");
    }
  }
}
