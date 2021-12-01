using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using blog.Entities;

namespace blog.Services
{
    public interface IPostService
    {
        Task<(bool IsSuccess, Exception Exception, Post Post)> CreateAsync(Post post);
        Task<List<Post>> GetAllAsync();
        Task<Post> GetAsync(Guid id);
        Task<List<Post>> GetTitleAsync(string title);
        Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Post post, Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<(bool IsSuccess, Exception Exception, Post post)> UpdateAsync(Post post);
        Task<(bool IsSuccess, Comment Comment)> AddCommentAsync(Comment comment, Guid id);

    }
}