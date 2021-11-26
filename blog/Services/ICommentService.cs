using System;
using System.Threading.Tasks;
using blog.Entities;

namespace blog.Services
{
    public interface ICommentService
    {
         Task<(bool IsSuccess, Exception Exception, Comment Comment)> CreateAsync(Comment comment);
    }
}