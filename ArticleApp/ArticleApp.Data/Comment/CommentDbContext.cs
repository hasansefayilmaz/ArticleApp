using Microsoft.EntityFrameworkCore;

namespace ArticleApp.Data.Comment
{
    public class CommentDbContext : DbContext
    {
        public CommentDbContext(DbContextOptions<CommentDbContext> options)
            : base(options)
        {
        }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);  
        }
    }
}
