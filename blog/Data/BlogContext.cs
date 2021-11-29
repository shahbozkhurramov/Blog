using blog.Entities;
using Microsoft.EntityFrameworkCore;

namespace blog.Data
{
    public class BlogContext: DbContext
    {
        public DbSet<Media> Medias { get; set; }
        
        public DbSet<Post> Posts { get; set; }
        
        public DbSet<Comment> Comments { get; set; }
        
        public BlogContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<Comment>()
            //     .HasOne(e => e.Post)
            //     .WithMany(c => c.Comments);

            // modelBuilder.Entity<Media>()
            //     .HasOne(e => e.Post)
            //     .WithMany(c => c.Medias);
        }
    }
}