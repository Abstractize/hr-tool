using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Persistence
{
    public abstract class Repository<T>
    {
        protected readonly EmployeeContext context;
        protected Repository(EmployeeContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
        public abstract Task<T> Create(T value);
        public abstract Task<T> Get(int id);
        public abstract Task<IEnumerable<T>> GetAll();
    }
}
