using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Persistence
{
    public interface IEmployeeDataRepository
    {
        Task<EmployeeData> Create(EmployeeData value);
        Task<EmployeeData> Get(int id);
        Task<IEnumerable<EmployeeData>> GetAll();
    }
}