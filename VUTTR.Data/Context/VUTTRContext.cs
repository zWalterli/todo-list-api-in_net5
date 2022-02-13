using Microsoft.EntityFrameworkCore;
using VUTTR.Domain.Models;

namespace VUTTR.Data.Context
{
    public class VUTTRContext : DbContext
    {
        public VUTTRContext(DbContextOptions<VUTTRContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region User
            builder.Entity<User>().ToTable("TB_VUTTR_User");
            builder.Entity<User>().HasKey(x => x.Id);
            builder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();
            #endregion

            #region Tool
            builder.Entity<Tool>().ToTable("TB_VUTTR_Tool");
            builder.Entity<Tool>().HasKey(x => x.Id);
            builder.Entity<Tool>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<Tool>()
                .HasMany(x => x.Tags)
                .WithOne(x => x.Tool)
                .HasForeignKey(x => x.ToolId);
            #endregion

            #region Tag
            builder.Entity<Tag>().ToTable("TB_VUTTR_Tag");
            builder.Entity<Tag>().HasKey(x => x.Id);
            builder.Entity<Tag>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<Tag>()
                .HasOne(x => x.Tool)
                .WithMany(x => x.Tags)
                .HasForeignKey(x => x.ToolId);
            #endregion
        }

        public DbSet<Tool> Tools { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
    }
}