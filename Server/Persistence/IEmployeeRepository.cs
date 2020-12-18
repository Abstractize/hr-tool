using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Persistence
{
    public interface IEmployeeRepository
    {
        Task<Employee> Create(Employee value);
        Task<Employee> Get(int id);
        Task<IEnumerable<Employee>> GetAll();
        Task CompleteAsync();
    }
}