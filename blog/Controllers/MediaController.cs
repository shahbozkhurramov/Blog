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
                return Ok(mediaModel.ToEntityMapper());
            }
            return BadRequest(result.Exception.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _ms.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetIdAsync(Guid id)
        {
            var result = await _ms.GetAsync(id);
            return Ok(result.Id);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var deletedResult = await _ms.DeleteAsync(id);
                
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