using System;
using System.Linq;
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
            var medias = postModel.MediaIds.Select(id => _ms.GetAsync(id).Result);

            var result = await _ps.CreateAsync(postModel.ToEntityMapper(medias));
            if(result.IsSuccess)
            {
                return Ok(result.Post);
            }
            return BadRequest(result.Exception.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _ps.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetIdAsync([FromRoute]Guid id)
        {
            var result = await _ps.GetAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("{title}/post")]
        public async Task<IActionResult> GetTitle([FromRoute]string title)
        {
            var result = await _ps.GetTitleAsync(title);
            return Ok(result);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletAsync([FromRoute]Guid id)
        {
            try
            {
                var post = await _ps.GetAsync(id);
                var deletedResult = await _ps.DeleteAsync(post, id);
                if(deletedResult.IsSuccess)
                {
                    return Ok();
                }
                return BadRequest(deletedResult.Exception.Message);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute]Guid id, [FromForm]UpdatedPost updatedPost)
        {
            try
            {
                var result = await _ps.GetAsync(id);
                result.Description = updatedPost.Description;
                result.Title = updatedPost.Title;
                result.Content = updatedPost.Content;
                result.ModifiedAt = DateTimeOffset.UtcNow;
                result.HeaderImageId = updatedPost.HeaderImageId;
                var deletedResult = await _ps.UpdateAsync(result);

                if(deletedResult.IsSuccess)
                {
                    return Ok();
                }
                return BadRequest(deletedResult.Exception.Message);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}