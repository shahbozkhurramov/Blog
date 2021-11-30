using System.Linq;
using System.Drawing;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace blog.Mappers
{
    public static class ToEntity
    {
        public static Entities.Post ToEntityMapper(this Models.PostModel postModel)
            => new Entities.Post()
            {
                Id = Guid.NewGuid(),
                Title = postModel.Title,
                Description = postModel.Description,
                Content = postModel.Content,
                Viewed = 0,
                CreatedAt = DateTimeOffset.UtcNow,
                ModifiedAt = postModel.ModifiedAt,
                Comments = null,
                Medias = null
            };
            
        public static Entities.Media ToEntityMapper(this Models.MediaModel mediaModel)
            => new Entities.Media()
            {
                Id = Guid.NewGuid(),
                ContentType = mediaModel.Data.ContentType,
                Data = ToByte(mediaModel.Data)
            };

        public static byte[] ToByte(IFormFile data)
        {
            var ms = new MemoryStream();
            data.CopyTo(ms);
            var fileBytes = ms.ToArray();
            return fileBytes;
        }
    }
}