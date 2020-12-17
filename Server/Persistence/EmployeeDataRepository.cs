using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Persistence
{
    public class EmployeeDataRepository : Repository<EmployeeData>
    {
        public EmployeeDataRepository(EmployeeContext context) : base(context)
        {
        }

        public override Task<EmployeeData> Create(EmployeeData value)
        {
            throw new System.NotImplementedException();
        }

        public override Task<EmployeeData> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public override Task<IEnumerable<EmployeeData>> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
