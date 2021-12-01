using System.Collections;
using System.Linq;
using System.Drawing;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;

namespace blog.Mappers
{
    public static class ToEntity
    {

        public static Entities.Post ToEntityMapper(this Models.PostModel postModel, 
        IEnumerable<Entities.Media> medias
        )
            => new Entities.Post()
                {
                    Id = Guid.NewGuid(),
                    Title = postModel.Title,
                    HeaderImageId = postModel.HeaderImageId,
                    Description = postModel.Description,
                    Content = postModel.Content,
                    Viewed = 1,
                    CreatedAt = DateTimeOffset.UtcNow,
                    Comments = null,
                    Medias = medias.ToList()
                };
            
        public static Entities.Media ToEntityMapper(this Models.MediaModel mediaModel)
            => new Entities.Media()
                {
                    Id = Guid.NewGuid(),
                    ContentType = mediaModel.Data.ContentType,
                    Data = ToByte(mediaModel.Data)
                };
        public static Entities.Comment ToEntityMapper(this Models.CommentModel commentModel)
            => new Entities.Comment()
            {
                Id = Guid.NewGuid(),
                Author = commentModel.Author,
                Content = commentModel.Content,
                PostId = commentModel.PostId,
                State = commentModel.State.ToEnumMappers()
            };
        public static Entities.Comment ToEntityMapper(this Models.UpdatedComment commentModel, Guid id, Entities.Comment comment)
            => new Entities.Comment()
                {
                    Id = id,
                    Author = comment.Author,
                    Content = commentModel.Content,
                    PostId = comment.PostId,
                    State = commentModel.State.ToEnumMappers()
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