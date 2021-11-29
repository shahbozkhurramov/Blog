using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Data;
using blog.Entities;
using Microsoft.EntityFrameworkCore;

namespace blog.Services
{
    public class PostService : IPostService
    {
        private readonly BlogContext _ctx;

        public PostService(BlogContext context)
        {
            _ctx = context;
        }

        public async Task<(bool IsSuccess, Exception Exception, Post Post)> CreateAsync(Post post)
        {
            try
            {
                await _ctx.Posts.AddAsync(post);
                await _ctx.SaveChangesAsync();
                return (true, null, post);
            }
            catch(Exception e)
            {
                return (false, e, null);
            }
        }


        public Task<bool> ExistsAsync(Guid id)
            => _ctx.Posts.AnyAsync(p => p.Id == id);

        public Task<List<Post>> GetAllAsync()
            => _ctx.Posts
                .AsNoTracking()
                .Include(m => m.Comments)
                .Include(m => m.Medias)
                .ToListAsync();

        public Task<List<Post>> GetAllAsync(string title)
            => _ctx.Posts
                .AsNoTracking()
                .Where(a => a.Title == title)
                .Include(m => m.Comments)
                .Include(m => m.Medias)
                .ToListAsync();

        public Task<Post> GetAsync(Guid id)
            => _ctx.Posts.FirstOrDefaultAsync(p => p.Id == id);

        public Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}