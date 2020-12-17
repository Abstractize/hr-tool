using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Persistence
{
    public class EmployeeRepository : Repository<Employee>
    {
        public EmployeeRepository(EmployeeContext context) : base(context)
        {
        }

        public override Task<Employee> Create(Employee value)
        {
            throw new System.NotImplementedException();
        }

        public override Task<Employee> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public override Task<IEnumerable<Employee>> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
