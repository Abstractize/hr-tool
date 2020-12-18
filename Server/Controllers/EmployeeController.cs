using AutoMapper;
using Server.Controllers.Resources;
using Server.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeDataRepository employeeDataRepository;

        public EmployeeController(IMapper mapper, IEmployeeRepository employeeRepository, IEmployeeDataRepository employeeDataRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
            this.employeeDataRepository = employeeDataRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Employee value)
        {
            var employeeModel = mapper.Map<Models.Employee>(value);
            employeeModel = await employeeRepository.Create(employeeModel);
            var data = mapper.Map<Models.EmployeeData>(value);
            data.IdEmployee = employeeModel.IdEmployee;
            data = await employeeDataRepository.Create(data);
            return Ok(mapper.Map<Employee>(data));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var value = await employeeRepository.Get(id);
            return Ok(mapper.Map<Employee>(value));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var value = (await employeeRepository.GetAll())
                .Where(emp => emp.IsActive == true);
            return Ok(mapper.Map<IEnumerable<Employee>>(value));
        }
        [HttpPut]
        public async Task<IActionResult> Put(Employee value)
        {
            var data = mapper.Map<Models.EmployeeData>(value);
            data = await employeeDataRepository.Create(data);
            return Ok(mapper.Map<Employee>(data));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await employeeRepository.Get(id);
            value.IsActive = false;
            await employeeRepository.CompleteAsync();
            return Ok(mapper.Map<Employee>(value));
        }
    }   
}
