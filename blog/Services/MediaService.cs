using System;
using System.Threading.Tasks;
using blog.Data;
using blog.Entities;

namespace blog.Services
{
    public class MediaService : IMediaService
    {
        private readonly BlogContext _ctx;

        public MediaService(BlogContext context)
        {
            _ctx = context;
        }
        public async Task<(bool IsSuccess, Exception Exception, Media Media)> CreateAsync(Media media)
        {
            try
            {
                await _ctx.Medias.AddAsync(media);
                await _ctx.SaveChangesAsync();
                return (true, null, media);
            }
            catch(Exception e)
            {
                return (false, e, null);
            }
        }
    }
}