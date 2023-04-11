using Assignment_ClassLibrary.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment_WebApi.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArticleRowEntity>().HasKey(x => new { x.ArticleId, x.AuthorId });

    }

    public DbSet<ArticleEntity> Articles { get; set; }
    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<ArticleRowEntity> ArticleRows { get; set; }
    public DbSet<ContentTypeEntity> ContentTypes { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
}
