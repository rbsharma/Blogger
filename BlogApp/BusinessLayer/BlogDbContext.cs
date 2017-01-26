using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogApp.BusinessLayer
{
    public class BlogDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Post>()
                        .HasMany(x=>x.Tags)
                        .WithMany(x=>x.Posts)
                        .Map(t => t.ToTable("tblPostTags").MapLeftKey("PostId").MapRightKey("TagId"));


            base.OnModelCreating(modelBuilder);
        }
    }
}