using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Persistence
{
    public interface IImageRepository
    {
        Task<Image> Create(Image value);
        Task<Image> Get(int id);
        Task<IEnumerable<Image>> GetAll();
    }
}