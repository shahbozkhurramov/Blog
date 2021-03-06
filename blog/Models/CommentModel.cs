using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace blog.Models
{
    public class CommentModel
    {   
        [MaxLength(255)]
        public string Author { get; set; }
        
        public string Content { get; set; }
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StateEnum? State { get; set; }

        [Required]
        public Guid PostId { get; set; }
    }
}