using AutoMapper;
using Server.Controllers.Resources;
using Server.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Server.Controllers
{
    /// <summary>
    /// API Connection for Employees
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeDataRepository employeeDataRepository;
        /// <summary>
        /// Creates an Employee Controller
        /// </summary>
        /// <param name="mapper">mapper that tranfers resources and models</param>
        /// <param name="employeeRepository">repository that contains the employees</param>
        /// <param name="employeeDataRepository">repository that contains the employee data</param>
        public EmployeeController(IMapper mapper, IEmployeeRepository employeeRepository, IEmployeeDataRepository employeeDataRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
            this.employeeDataRepository = employeeDataRepository;
        }

        /// <summary>
        /// Posts value into Employee Repository.
        /// </summary>
        /// <param name="value">employee to be created</param>
        /// <returns>
        /// Employee posted with ID created for the Repository.
        /// </returns>
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
        /// <summary>
        /// Gets Employee from the Employee Repository with the given id.
        /// </summary>
        /// <param name="id">ID of wanted employee</param>
        /// <returns>
        /// Employee with given ID.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var value = await employeeRepository.Get(id);
            return Ok(mapper.Map<Employee>(value));
        }
        /// <summary>
        /// Gets all the Employees Active Employess from the Emloyee Repository.
        /// </summary>
        /// <returns>
        /// All the employees in the Repository.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var value = (await employeeRepository.GetAll())
                .Where(emp => emp.IsActive == true);
            return Ok(mapper.Map<IEnumerable<Employee>>(value));
        }
        /// <summary>
        /// Updates the employee with same ID in the Employee Repository with the given value.
        /// </summary>
        /// <param name="value">Values to update the employee.</param>
        /// <returns>
        /// Updated employee with the updated values.
        /// </returns>
        [HttpPut]
        public async Task<IActionResult> Put(Employee value)
        {
            var data = mapper.Map<Models.EmployeeData>(value);
            data = await employeeDataRepository.Create(data);
            return Ok(mapper.Map<Employee>(data));
        }
        /// <summary>
        /// Deactivates the employee with given id from the Employee Repository.
        /// </summary>
        /// <param name="id">ID of the employee to Deactivate</param>
        /// <returns>
        /// Deactived employee that has the given id.
        /// </returns>
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
