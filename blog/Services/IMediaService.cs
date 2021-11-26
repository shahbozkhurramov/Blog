using System;
using System.Threading.Tasks;
using blog.Entities;

namespace blog.Services
{
    public interface IMediaService
    {
         Task<(bool IsSuccess, Exception Exception, Media Media)> CreateAsync(Media media);

         
    }
}