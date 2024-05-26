using Asp.NetIntro_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Asp.NetIntro_MVC.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }

        public DbSet<SliderInfo> Sliderinfos { get; set; }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slider>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Blog>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Expert>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(m => !m.SoftDeleted);


            modelBuilder.Entity<SocialMedia>().HasData(
             new SocialMedia
             {
                 Id = 1,
                 Name = "Twitter",
                 Url = "www.twitter.com",
                 SoftDeleted = false,
                 CreatedDate = DateTime.Now,

             },
             new SocialMedia
             {
                 Id = 2,
                 Name = "Instagram",
                 Url = "www.instagram.com",
                 SoftDeleted = false,
                 CreatedDate = DateTime.Now,

             },
                 new SocialMedia
                 {
                     Id = 3,
                     Name = "Tumblr",
                     Url = "www.tumblr.com",
                     SoftDeleted = false,
                     CreatedDate = DateTime.Now,
                 },
                 new SocialMedia
                 {
                     Id = 4,
                     Name = "Pinterest",
                     Url = "www.pinterest.com",
                     SoftDeleted = false,
                     CreatedDate = DateTime.Now,
                 }
         );
            modelBuilder.Entity<Setting>().HasData(
               new Setting
               {
                   Id = 1,
                   Key = "HeaderLogo",
                   Value = "logo.png",
                   SoftDeleted = false,
                   CreatedDate = DateTime.Now,

               },
               new Setting
               {
                   Id = 2,
                   Key = "Phone",
                   Value = "23491012",
                   SoftDeleted = false,
                   CreatedDate = DateTime.Now,

               },
                   new Setting
                   {
                       Id = 3,
                       Key = "Address",
                       Value = "Ehmedli",
                       SoftDeleted = false,
                       CreatedDate = DateTime.Now,
                   }
           );
            modelBuilder.Entity<Blog>().HasData(
         new Blog
         {
             Id = 1,
             Title = "Title1",
             Description="Reshadin blogu",
             Image = "blog-feature-img-1.jpg",
             CreatedDate = DateTime.Now
         },
           new Blog
           {
               Id = 2,
               Title = "Title2",
               Description = "Ilqarin blogu",
               Image = "blog-feature-img-3.jpg",
               CreatedDate = DateTime.Now
           },
             new Blog
             {
                 Id = 3,
                 Title = "Title3",
                 Description = "Hacixanin blogu",
                 Image = "blog-feature-img-4.jpg",
                 CreatedDate = DateTime.Now
             }
         );



        }


    }
}
