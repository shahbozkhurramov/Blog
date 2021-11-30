using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace blog.Models
{
    public class MediaModel
    {
        [Required]
        public IFormFile Data { get; set; }
    }
}