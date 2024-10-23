using AutoMapper;
using Kian.task.Core.Entities;
using Kian.task.Core.Interfaces;
using Kian.task.Core.Specifications;
using Kian.Task.Presentation.Dtos;
using Kian.Task.Presentation.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kian.Task.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRebository _employeeRebository;
        private readonly IMapper _mapper;
        private readonly IGenericRebository<Employee> _genericRebository;

        public EmployeeController(IGenericRebository<Employee> genericRebository,
                                  IMapper mapper,
                                  IEmployeeRebository employeeRebository)
        {
            _genericRebository = genericRebository;
            _mapper = mapper;
            _employeeRebository = employeeRebository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<Pagination<EmployeeDto>>> GetEmployees([FromQuery] EmployeeSpecParams employeeSpecParams)
        {
            var specification = new EmployeeWithSpecifications(employeeSpecParams);
            var totalCount = await _genericRebository.CountAsync(specification);
            var employees = await _genericRebository.ListAsync(specification);
            var employeeDtos = _mapper.Map<IReadOnlyList<EmployeeDto>>(employees);

            return Ok(new Pagination<EmployeeDto>(employeeSpecParams.PageIndex, employeeSpecParams.PageSize, totalCount, employeeDtos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            var employee = await _employeeRebository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<EmployeeDto>(employee));
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> AddEmployee([FromBody] EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = _mapper.Map<Employee>(employeeDto);
            await _employeeRebository.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employeeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (employeeDto == null)
            {
                return BadRequest("Employee data is required.");
            }

            var employee = await _employeeRebository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }

            employee.FirstName = employeeDto.FirstName;
            employee.LastName = employeeDto.LastName;
            employee.UserName = employeeDto.UserName;
            employee.Salary = employeeDto.Salary;

            await _employeeRebository.UpdateEmployeeAsync(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeRebository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            await _employeeRebository.DeleteEmployeeAsync(employee);
            return NoContent();
        }
    }
}
