using System.Collections.Generic;
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
            var modelBuildUser = modelBuilder.Entity<User>();
            modelBuildUser.ToTable("user");
            modelBuildUser.HasKey(x => x.UserId);
            modelBuildUser.Property(x => x.UserId).ValueGeneratedOnAdd();

            var modelBuildTool = modelBuilder.Entity<Tool>();
            modelBuildTool.ToTable("tool");
            modelBuildTool.HasKey(x => x.id);
            modelBuildTool.Property(x => x.id).ValueGeneratedOnAdd();
            modelBuildTool.HasMany(x => x.Tags)
                .WithOne(x => x.Tool);

            var modelBuildTag = modelBuilder.Entity<Tag>();
            modelBuildTag.ToTable("tag");
            modelBuildTag.HasKey(x => x.id);
            modelBuildTag.Property(x => x.id).ValueGeneratedOnAdd();
            modelBuildTag.HasOne(x => x.Tool)
                .WithMany( x => x.Tags);            
        }

        public DbSet<Tool> Tools { get; set; }  
        public DbSet<Tag> Tags { get; set; }  
        public DbSet<User> Users { get; set; }  
    }
}