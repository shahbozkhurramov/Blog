using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Data;
using blog.Entities;
using Microsoft.EntityFrameworkCore;

namespace blog.Services
{
    public class CommentService : ICommentService
    {
        private readonly BlogContext _ctx;

        public CommentService(BlogContext context)
        {
            _ctx = context;
        }

        public async Task<(bool IsSuccess, Exception Exception, Comment Comment)> CreateAsync(Comment comment)
        {
            try
            {
                await _ctx.Comments.AddAsync(comment);
                await _ctx.SaveChangesAsync();
                return (true, null, comment);
            }
            catch(Exception e)
            {
                return (false, e, null);
            }
        }

        public Task<bool> ExistsAsync(Guid id)
            => _ctx.Comments.AnyAsync(c => c.Id == id);

        public Task<List<Comment>> GetAllAsync(Guid id)
            => _ctx.Comments.Where(m => m.PostId == id).ToListAsync();

        public Task<Comment> GetAsync(Guid id)
            => _ctx.Comments.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id)
        {
            try
            {
                var comment = await GetAsync(id);
                _ctx.Comments.Remove(comment);
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