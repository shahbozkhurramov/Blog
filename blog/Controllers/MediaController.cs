using System;
using System.IO;
using System.Threading.Tasks;
using blog.Entities;
using blog.Mappers;
using blog.Models;
using blog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaController: ControllerBase
    {
        private readonly IMediaService _ms;

        public MediaController(IMediaService mediaService)
        {
            _ms = mediaService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm]MediaModel mediaModel)
        {
            var result = await _ms.CreateAsync(mediaModel.ToEntityMapper());
            if(result.IsSuccess)
            {
                return Ok(mediaModel);
            }
            return BadRequest(result.Exception.Message);
        }

        private Media GetImageEntity(IFormFile file)
        {
            using var stream = new MemoryStream();

            file.CopyTo(stream);

            return new Media()
            {
                Id = Guid.NewGuid(),
                ContentType = file.ContentType,
                Data = stream.ToArray()
            };
        }
    }
}