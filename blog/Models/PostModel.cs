using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace blog.Models
{
    public class PostModel
    {
        public Guid HeaderImageId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        
        [MaxLength(255)]
        public string Description { get; set; }
        
        [MaxLength(50000)]
        public string Content { get; set; }
        
        public int Viewed { get; set; }
        
        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset ModifiedAt { get; set; }
        
        public List<CommentModel> CommentModels { get; set; }

        public List<MediaModel> MediaModels { get; set; }
    }

}