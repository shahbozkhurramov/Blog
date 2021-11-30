using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using blog.Entities;

namespace blog.Services
{
    public interface ICommentService
    {
        Task<(bool IsSuccess, Exception Exception, Comment Comment)> CreateAsync(Comment comment);
        Task<bool> ExistsAsync(Guid id);
        Task<List<Comment>> GetAllAsync();
        Task<Comment> GetAsync(Guid id);
        Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id);
        Task<(bool IsSuccess, Exception Exception, Comment Comment)> UpdateActorAsync(Comment comment);
    }
}