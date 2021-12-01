using System.Net;
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
    public class CommentController: ControllerBase
    {
        private readonly ICommentService _cs;
        private readonly IPostService _ps;

        public CommentController(ICommentService commentService, IPostService postService)
        {
            _cs = commentService;
            _ps = postService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm]CommentModel comment)
        {
            var result = await _cs.CreateAsync(comment.ToEntityMapper());
            var res = await _ps.AddCommentAsync(result.Comment, comment.PostId);
            if(res.IsSuccess)
            {
                return Ok(res.Comment);
            }
            return BadRequest(result.Exception.Message);
        }

        [HttpGet]
        [Route("{id}/post")]
        public async Task<IActionResult> GetAllAsync([FromRoute]Guid id)
        {
            var result = await _cs.GetAllAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute]Guid id)
        {
            try
            {
                var result = await _cs.GetAsync(id);
                return Ok(result);
            }
            catch
            {
                return NotFound("Comment does not exist!");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]Guid id)
        {
            var result = await _cs.DeleteAsync(id);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute]Guid id, [FromForm]string content)
        {
            var res = await _cs.GetAsync(id);
            res.Content = content;
            if(res is not null) return Ok(res);
            return BadRequest("Does not exist");
        }

    }
}