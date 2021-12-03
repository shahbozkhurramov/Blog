using System.Collections;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace blog.Models
{
    public class PostModel
    {
        public Guid? HeaderImageId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        
        [MaxLength(255)]
        public string Description { get; set; }
        
        [MaxLength(50000)]
        public string Content { get; set; }
        
        public IEnumerable<Guid> MediaIds { get; set; } 
    }

}