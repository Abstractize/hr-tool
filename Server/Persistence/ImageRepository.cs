using Microsoft.EntityFrameworkCore;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Persistence
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(EmployeeContext context) : base(context)
        {

        }
        public async override Task<Image> Create(Image value)
        {
            var result = await context.Images.AddAsync(value);
            return result.Entity;
        }

        public async override Task<Image> Get(int id)
        {
            return await context.Images.FindAsync(id);
        }

        public async override Task<IEnumerable<Image>> GetAll()
        {
            return await context.Images.ToArrayAsync();
        }
    }
}
