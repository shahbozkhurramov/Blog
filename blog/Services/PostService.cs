using System.Net.NetworkInformation;
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

        public Task<List<Post>> GetTitleAsync(string title)
            => _ctx.Posts
                .AsNoTracking()
                .Where(a => a.Title == title)
                .Include(m => m.Comments)
                .Include(m => m.Medias)
                .ToListAsync();

        public Task<Post> GetAsync(Guid id)
            =>  _ctx.Posts
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Include(p => p.Medias)
                .OrderBy(p => p.Id)
                .FirstOrDefaultAsync();

        public async Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Post post, Guid id)
        {
            try
            {
                try
                {
                    var medias = post.Medias.ToList();
                    
                    foreach(var media in medias)
                    {
                        _ctx.Medias.Remove(media);
                        await _ctx.SaveChangesAsync();
                    }

                    var comments = post.Comments.ToList();
                    foreach(var comment in comments)
                    {
                        _ctx.Comments.Remove(comment);
                        await _ctx.SaveChangesAsync();
                    }
                    _ctx.Posts.Remove(post);
                    await _ctx.SaveChangesAsync();
                    return (true, null);
                }
                catch
                {
                    _ctx.Posts.Remove(post);
                    await _ctx.SaveChangesAsync();
                    return (true, null);
                }
            }
            catch(Exception e)
            {
                return (false, e);
            }
        }

        public async Task<(bool IsSuccess, Exception Exception, Post post)> UpdateAsync(Post post)
        {
            if(!await ExistsAsync(post.Id))
            {
                return (false, new ArgumentException("Does not exist!"), null);
            }

            _ctx.Posts.Update(post);
            await _ctx.SaveChangesAsync();
            return (true, null, post);
        }

        public async Task<(bool IsSuccess, Comment Comment)> AddCommentAsync(Comment comment, Guid id)
        {
            try
            {
                var post = _ctx.Posts.FirstOrDefault(p => p.Id == id);
                post.Comments.Add(comment);
                _ctx.Posts.Update(post);
                await _ctx.SaveChangesAsync();
                return (true, comment);
            }
            catch
            {
                return (false, null);
            }
        }
    }
}