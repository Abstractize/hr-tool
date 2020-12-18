using Microsoft.EntityFrameworkCore;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Persistence
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeContext context) : base(context)
        {
        }

        public override async Task<Employee> Create(Employee value)
        {
            var entity = await context.Employees.AddAsync(value);
            await context.SaveChangesAsync();
            return entity.Entity;
        }

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
