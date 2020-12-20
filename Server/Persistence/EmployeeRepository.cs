using Microsoft.EntityFrameworkCore;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Persistence
{
    /// <summary>
    /// Repository that stores the employees
    /// </summary>
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        /// <summary>
        /// Creates a Repository that comunicates with the given context.
        /// </summary>
        /// <param name="context">context to connect the repository</param>
        public EmployeeRepository(EmployeeContext context) : base(context)
        {
        }
        /// <summary>
        /// Creates an Employee on the context with the given value.
        /// </summary>
        /// <param name="value">value to create</param>
        /// <returns>
        /// Created Employee
        /// </returns>
        public override async Task<Employee> Create(Employee value)
        {
            var entity = await context.Employees.AddAsync(value);
            await context.SaveChangesAsync();
            return entity.Entity;
        }
        /// <summary>
        /// Gets Employee with the given id.
        /// </summary>
        /// <param name="id">EmployeeData id</param>
        /// <returns>
        /// Employee with the given id.
        /// </returns>
        public override async Task<Employee> Get(int id)
        {
            var entity = await context.Employees
                .Include(emp => emp.EmployeeDatumIdEmployeeNavigations)
                    .ThenInclude(data => data.IdManagerNavigation)
                .Include(emp => emp.EmployeeDatumIdEmployeeNavigations)
                    .ThenInclude(data => data.IdImageNavigation)
                .SingleOrDefaultAsync(emp => emp.IdEmployee == id);
            return entity;
        }
        /// <summary>
        /// Get all the activated employees in the repository.
        /// </summary>
        /// <returns>
        /// All the activated employees.
        /// </returns>
        public override async Task<IEnumerable<Employee>> GetAll()
        {
            return await context.Employees
                .Include(emp => emp.EmployeeDatumIdEmployeeNavigations)
                    .ThenInclude(data => data.IdManagerNavigation)
                .Include(emp => emp.EmployeeDatumIdEmployeeNavigations)
                    .ThenInclude(data => data.IdImageNavigation)
                .ToListAsync();
        }
    }
}
