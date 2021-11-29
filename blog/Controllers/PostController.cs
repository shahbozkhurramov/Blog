using System.Net.Http.Headers;
using System.Threading.Tasks;
using blog.Entities;
using blog.Mappers;
using blog.Models;
using blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController: ControllerBase
    {
        private readonly IPostService _ps;
        private readonly ICommentService _cs;
        private readonly IMediaService _ms;

        public PostController(IPostService postService, ICommentService commentService, IMediaService mediaService)
        {
            _ps = postService;
            _cs = commentService;
            _ms = mediaService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm]PostModel postModel)
        {
            var result = await _ps.CreateAsync(postModel.ToEntityMapper());
            if(result.IsSuccess)
            {
                return Ok();
            }
            return BadRequest(result.Exception.Message);
        }
    }
}