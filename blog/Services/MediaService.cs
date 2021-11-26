using System;
using System.Threading.Tasks;
using blog.Entities;

namespace blog.Services
{
    public class MediaService : IMediaService
    {
        public Task<(bool IsSuccess, Exception Exception, Media Media)> CreateAsync(Media media)
        {
            throw new NotImplementedException();
        }
    }
}