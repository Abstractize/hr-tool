using Microsoft.EntityFrameworkCore;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Persistence
{
    public class EmployeeDataRepository : Repository<EmployeeData>, IEmployeeDataRepository
    {
        public EmployeeDataRepository(EmployeeContext context) : base(context)
        {
        }

        public override async Task<EmployeeData> Create(EmployeeData value)
        {
            var entity = await context.EmployeeData.AddAsync(value);
            await context.SaveChangesAsync();
            return entity.Entity;
        }

        public override async Task<EmployeeData> Get(int id)
        {
            var entity = await context.EmployeeData
                .Include(data => data.IdEmployeeNavigation)
                .Include(data => data.IdManagerNavigation)
                .Include(data => data.IdImageNavigation)
                .SingleOrDefaultAsync(data => data.IdEmployeeData == id);
            return entity;
        }

        public override async Task<IEnumerable<EmployeeData>> GetAll()
        {
            return await context.EmployeeData.ToListAsync();
        }
    }
}
