using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Entities
{
    public class Media
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [MaxLength(55)]
        public string ContentType { get; set; }

        [Required]
        [MaxLength(5 * 1024 * 1024)]
        public byte[] Data { get; set; }
        
        [Required]
        public Guid PostId { get; set; }

        public Post Post { get; set; }
    }
}