using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Persistence
{
    /// <summary>
    /// Interface of the Repository that stores the employees
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Creates an Employee on the context with the given value.
        /// </summary>
        /// <param name="value">value to create</param>
        /// <returns>
        /// Created Employee
        /// </returns>
        Task<Employee> Create(Employee value);
        /// <summary>
        /// Gets Employee with the given id.
        /// </summary>
        /// <param name="id">EmployeeData id</param>
        /// <returns>
        /// Employee with the given id.
        /// </returns>
        Task<Employee> Get(int id);
        /// <summary>
        /// Get all the activated employees in the repository.
        /// </summary>
        /// <returns>
        /// All the activated employees.
        /// </returns>
        Task<IEnumerable<Employee>> GetAll();
        /// <summary>
        /// Save changes on the repository.
        /// </summary>
        /// <returns>
        /// Awaitable Save Task.
        /// </returns>
        Task CompleteAsync();
    }
}