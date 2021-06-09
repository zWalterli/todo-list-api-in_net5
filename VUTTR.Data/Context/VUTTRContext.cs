using Microsoft.EntityFrameworkCore;
using VUTTR.Domain.Models;

namespace VUTTR.Data.Context
{
    public class VUTTRContext : DbContext
    {
        public VUTTRContext(DbContextOptions<VUTTRContext> options) : base(options)  
        {  }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("user");

            modelBuilder.Entity<Tool>().ToTable("tool");
            modelBuilder.Entity<Tool>()
                .HasMany(x => x.Tags)
                .WithOne(x => x.Tool);

            modelBuilder.Entity<Tag>().ToTable("tag");
            modelBuilder.Entity<Tag>()
                .HasOne(x => x.Tool)
                .WithMany( x => x.Tags);
        }

        public DbSet<Tool> Tools { get; set; }  
        public DbSet<Tag> Tags { get; set; }  
        public DbSet<User> Users { get; set; }  
    }
}