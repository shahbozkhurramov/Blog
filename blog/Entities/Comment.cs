using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Entities
{
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        
        [MaxLength(255)]
        public string Author { get; set; }
        
        public string Content { get; set; }
        
        public StateEnum State { get; set; }

        [Required]
        public Guid PostId { get; set; }
        
        public Post Post { get; set; }  
    }
}