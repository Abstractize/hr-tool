using Microsoft.EntityFrameworkCore;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Persistence
{
    /// <summary>
    /// Repository that stores the employees data
    /// </summary>
    public class EmployeeDataRepository : Repository<EmployeeData>, IEmployeeDataRepository
    {
        /// <summary>
        /// Creates a Repository that comunicates with the given context.
        /// </summary>
        /// <param name="context">context to connect the repository</param>
        public EmployeeDataRepository(EmployeeContext context) : base(context)
        {
        }
        /// <summary>
        /// Creates an EmployeeData on the context with the given value.
        /// </summary>
        /// <param name="value">value to create</param>
        /// <returns>
        /// Created EmployeeData
        /// </returns>
        public override async Task<EmployeeData> Create(EmployeeData value)
        {
            var entity = await context.EmployeeData.AddAsync(value);
            await context.SaveChangesAsync();
            return entity.Entity;
        }
        /// <summary>
        /// Gets Employee Data with the given id.
        /// </summary>
        /// <param name="id">EmployeeData id</param>
        /// <returns>
        /// Employee Data with the given id.
        /// </returns>
        public override async Task<EmployeeData> Get(int id)
        {
            var entity = await context.EmployeeData
                .Include(data => data.IdEmployeeNavigation)
                .Include(data => data.IdManagerNavigation)
                .Include(data => data.IdImageNavigation)
                .SingleOrDefaultAsync(data => data.IdEmployeeData == id);
            return entity;
        }
        /// <summary>
        /// Get all the employees data in the repository.
        /// </summary>
        /// <returns>
        /// All the employees data.
        /// </returns>
        public override async Task<IEnumerable<EmployeeData>> GetAll()
        {
            return await context.EmployeeData.ToListAsync();
        }
    }
}
