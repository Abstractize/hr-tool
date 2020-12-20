using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Persistence
{
    /// <summary>
    /// Interface of the Repository that stores the employees data
    /// </summary>
    public interface IEmployeeDataRepository
    {
        /// <summary>
        /// Creates an EmployeeData on the context with the given value.
        /// </summary>
        /// <param name="value">value to create</param>
        /// <returns>
        /// Created EmployeeData
        /// </returns>
        Task<EmployeeData> Create(EmployeeData value);
        /// <summary>
        /// Gets Employee Data with the given id.
        /// </summary>
        /// <param name="id">EmployeeData id</param>
        /// <returns>
        /// Employee Data with the given id.
        /// </returns>
        Task<EmployeeData> Get(int id);
        /// <summary>
        /// Get all the employees data in the repository.
        /// </summary>
        /// <returns>
        /// All the employees data.
        /// </returns>
        Task<IEnumerable<EmployeeData>> GetAll();
    }
}