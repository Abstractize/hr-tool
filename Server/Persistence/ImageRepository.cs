using Microsoft.EntityFrameworkCore;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Persistence
{
    /// <summary>
    /// Repository that stores the employees images
    /// </summary>
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        /// <summary>
        /// Creates a Repository that comunicates with the given context.
        /// </summary>
        /// <param name="context">context to connect the repository</param>
        public ImageRepository(EmployeeContext context) : base(context)
        {

        }
        /// <summary>
        /// Creates an Image on the context with the given value.
        /// </summary>
        /// <param name="value">value to create</param>
        /// <returns>
        /// Created Image
        /// </returns>
        public async override Task<Image> Create(Image value)
        {
            var result = await context.Images.AddAsync(value);
            await context.SaveChangesAsync();
            return result.Entity;
        }
        /// <summary>
        /// Gets Image with the given id.
        /// </summary>
        /// <param name="id">EmployeeData id</param>
        /// <returns>
        /// Image with the given id.
        /// </returns>
        public async override Task<Image> Get(int id)
        {
            return await context.Images.FindAsync(id);
        }
        /// <summary>
        /// Get all the images in the repository.
        /// </summary>
        /// <returns>
        /// All the images.
        /// </returns>
        public async override Task<IEnumerable<Image>> GetAll()
        {
            return await context.Images.ToArrayAsync();
        }
    }
}
