using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Persistence
{
    /// <summary>
    /// Interface of the Repository that stores the employees images
    /// </summary>
    public interface IImageRepository
    {
        /// <summary>
        /// Creates an Image on the context with the given value.
        /// </summary>
        /// <param name="value">value to create</param>
        /// <returns>
        /// Created Image
        /// </returns>
        Task<Image> Create(Image value);
        /// <summary>
        /// Gets Image with the given id.
        /// </summary>
        /// <param name="id">EmployeeData id</param>
        /// <returns>
        /// Image with the given id.
        /// </returns>
        Task<Image> Get(int id);
        /// <summary>
        /// Get all the images in the repository.
        /// </summary>
        /// <returns>
        /// All the images.
        /// </returns>
        Task<IEnumerable<Image>> GetAll();
    }
}