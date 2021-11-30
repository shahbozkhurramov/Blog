using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using blog.Entities;

namespace blog.Services
{
    public interface IMediaService
    {
        Task<(bool IsSuccess, Exception Exception, Media Media)> CreateAsync(Media media);
        Task<bool> ExistsAsync(Guid id);
        Task<List<Media>> GetAllAsync();
        Task<Media> GetAsync(Guid id);
        Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id);
    }
}