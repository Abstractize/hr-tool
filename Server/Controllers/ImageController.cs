using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Persistence;
using System.IO;
using System.Threading.Tasks;

namespace Server.Controllers
{
    /// <summary>
    /// API Connection for Images
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository imageRepository;
        private readonly IMapper mapper;
        /// <summary>
        /// Creates an Image Controller.
        /// </summary>
        /// <param name="imageRepository">repository that contains the employees images</param>
        /// <param name="mapper">mapper that tranfers resources and models</param>
        public ImageController(IImageRepository imageRepository, IMapper mapper)
        {
            this.imageRepository = imageRepository;
            this.mapper = mapper;
        }
        /// <summary>
        /// Post an Image with given FormFile image.
        /// </summary>
        /// <param name="image">Formfile that contains the image.</param>
        /// <returns>
        /// Resource Model of image posted with url for getting it and Image ID.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFile image)
        {
            byte[] fileBytes;

            using (var stream = new MemoryStream())
            {
                await image.CopyToAsync(stream);
                fileBytes = stream.ToArray();
            }

            var data = await imageRepository.Create(new Models.Image { Data = fileBytes });

            return Ok(mapper.Map<Resources.Image>(data));
        }
        /// <summary>
        /// Gets Image with the given ID.
        /// </summary>
        /// <param name="id">Image ID</param>
        /// <returns>
        /// Image with the given ID.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await imageRepository.Get(id);
            byte[] images = result.Data;
            var file = File(images, "image/jpeg");
            return file;
        }
    }
}
