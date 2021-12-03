using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace blog.Entities
{
    public class Post
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        
        public Guid? HeaderImageId { get; set; }

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
        
        public ICollection<Comment> Comments { get; set; }

        public ICollection<Media> Medias { get; set; }
    }

}