using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TvPlus.Core.Models;
using System.Linq.Expressions;

namespace TvPlus.DataAccess
{
    public class MyDbContext : IdentityDbContext<User>
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<SystemParameter> SystemParameters { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<CenterType> CenterTypes { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<RelationRule> RelationRules { get; set; }
        public DbSet<RelationType> RelationTypes { get; set; }
        public DbSet<SpecialEvent> SpecialEvents { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<VideoConvert> VideoConverts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<NavigationMenu> NavigationMenu { get; set; }
        public DbSet<RoleMenuPermission> RoleMenuPermission { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CenterCategory> CenterCategories { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<AboutUsSection> AboutUsSections { get; set; }
        public DbSet<ContactUsInfo> ContactUsInfoes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SubscriptionPackage> SubscriptionPackages { get; set; }


        public DbSet<PComments> ZComments { get; set; }
        public DbSet<PTags> ZTags { get; set; }
        public DbSet<PVideos> ZVideos { get; set; }
        public DbSet<PVideo_Tag> ZVideo_Tag { get; set; }
        public DbSet<PVideo_Category> ZVideo_Category { get; set; }
        public DbSet<PVideo_Convert> ZVideo_Convert { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleMenuPermission>()
            .HasKey(c => new { c.RoleId, c.NavigationMenuId });

            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<People>().ToTable("Centers_People");
            modelBuilder.Entity<Post>().ToTable("Centers_Posts");
            modelBuilder.Entity<SpecialEvent>().ToTable("Centers_SpecialEvents");
            modelBuilder.Entity<Tag>().ToTable("Centers_Tags");

            modelBuilder.Entity<RelationRule>()
                .HasOne(n => n.FirstCenter)
                .WithMany(m => m.RelationRules1)
                .HasForeignKey(n => n.CenterTypeId1)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RelationRule>()
                .HasOne(n => n.SecondCenter)
                .WithMany(m => m.RelationRules2)
                .HasForeignKey(n => n.CenterTypeId2)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Member>()
                .HasOne(n => n.Center1)
                .WithMany(m => m.Members1)
                .HasForeignKey(n => n.CenterId1)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Member>()
                .HasOne(n => n.Center2)
                .WithMany(m => m.Members2)
                .HasForeignKey(n => n.CenterId2)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(n => n.User)
                .WithMany(m => m.Comments)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
