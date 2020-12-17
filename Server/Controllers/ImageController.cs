using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Persistence;
using System.IO;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ImageRepository imageRepository;
        private readonly IMapper _mapper;

        public ImageController(ImageRepository imageRepository, IMapper mapper)
        {
            this.imageRepository = imageRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage([FromForm] IFormFile image)
        {
            byte[] fileBytes;

            using (var stream = new MemoryStream())
            {
                await image.CopyToAsync(stream);
                fileBytes = stream.ToArray();
            }

            var data = await imageRepository.Create(new Models.Image { Data = fileBytes });

            return Ok(_mapper.Map<Resources.Image>(data));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImage(int id)
        {
            var result = await imageRepository.Get(id);
            byte[] images = result.Data;
            var file = File(images, "image/jpeg");
            return file;
        }
    }
}
