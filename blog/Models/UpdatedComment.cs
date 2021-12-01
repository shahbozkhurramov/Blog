using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace blog.Models
{
    public class UpdatedComment
    {   
        public string Content { get; set; }
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StateEnum? State { get; set; }
    }
}