using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Persistence
{
    /// <summary>
    /// Abstract Repository that stores the T data
    /// </summary>
    /// <typeparam name="T">Type of the repository stored value</typeparam>
    public abstract class Repository<T>
    {
        protected readonly EmployeeContext context;
        /// <summary>
        /// Creates a Repository that comunicates with the given context.
        /// </summary>
        /// <param name="context">context to connect the repository</param>
        protected Repository(EmployeeContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Save changes on the repository.
        /// </summary>
        /// <returns>
        /// Awaitable Save Task.
        /// </returns>
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// Creates a T on the context with the given value.
        /// </summary>
        /// <param name="value">value to create</param>
        /// <returns>
        /// Created T
        /// </returns>
        public abstract Task<T> Create(T value);
        /// <summary>
        /// Gets a T with the given id.
        /// </summary>
        /// <param name="id">EmployeeData id</param>
        /// <returns>
        /// T with the given id.
        /// </returns>
        public abstract Task<T> Get(int id);
        /// <summary>
        /// Get all the T in the repository.
        /// </summary>
        /// <returns>
        /// All the T.
        /// </returns>
        public abstract Task<IEnumerable<T>> GetAll();
    }
}
