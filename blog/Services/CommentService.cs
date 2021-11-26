using System;
using System.Threading.Tasks;
using blog.Entities;

namespace blog.Services
{
    public class CommentService : ICommentService
    {
        public Task<(bool IsSuccess, Exception Exception, Comment Comment)> CreateAsync(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}