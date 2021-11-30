using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using blog.Data;
using blog.Entities;
using Microsoft.EntityFrameworkCore;

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

        public Task<bool> ExistsAsync(Guid id)
            => _ctx.Medias.AnyAsync(m => m.Id == id);

        public Task<List<Media>> GetAllAsync()
            => _ctx.Medias.ToListAsync();

        public Task<Media> GetAsync(Guid id)
            => _ctx.Medias.FirstOrDefaultAsync(m => m.Id == id);

        public async Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id)
        {
            try
            {
                var media = await GetAsync(id);
                _ctx.Medias.Remove(media);
                await _ctx.SaveChangesAsync();
                return (true, null);
            }
            catch(Exception e)
            {
                return (false, e);
            }
        }
    }
}