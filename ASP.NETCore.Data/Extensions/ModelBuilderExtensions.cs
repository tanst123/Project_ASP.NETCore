﻿using ASP.NETCore.Data.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NETCore.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() {Key="HomeTitle", Value = "This is home page of eShopSolution"},
                new AppConfig() {Key="HomeKeyword", Value = "This is keyword of eShopSolution"},
                new AppConfig() {Key="HomeDescription", Value = "This is description of eShopSolution"}
           );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", isDefault = true },
                new Language() { Id = "en-US", Name = "Tiếng Anh", isDefault = false }
           );

            modelBuilder.Entity<Category>().HasData(
                 new Category()
                 {
                     Id = 1,
                     IsShowOnHome = true,
                     ParentId = null,
                     SortOrder = 1,
                     Status = Enums.StatusEnum.Active,
                 },
                 new Category()
                 {
                     Id = 2,
                     IsShowOnHome = true,
                     ParentId = null,
                     SortOrder = 2,
                     Status = Enums.StatusEnum.Active,
                    
                 }
           );

            modelBuilder.Entity<CategoryTranslation>().HasData(
                 new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Áo nam", LanguageId = "vi-VN", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm áo thời trang nam", SeoTitle = "Sản phẩm áo thời trang nam" },
                 new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Men Shirt", LanguageId = "en-US", SeoAlias = "men-shirt", SeoDescription = "The shirt product for men", SeoTitle = "The shirt product for men" },
                 new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Áo nữ", LanguageId = "vi-VN", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm áo thời trang nữ", SeoTitle = "Sản phẩm áo thời trang nữ" },
                 new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Women Shirt", LanguageId = "en-US", SeoAlias = "women-shirt", SeoDescription = "The shirt product for women", SeoTitle = "The shirt product for women" }
                );

            modelBuilder.Entity<Product>().HasData(
                 new Product()
                 {
                      Id = 1,
                      DateCreated = DateTime.Now,
                      OriginalPrice = 100000,
                      Price = 200000,
                      Stock = 0,
                      ViewCount = 0,
                 }
            );

            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation() {Id = 1, ProductId = 1, Name = "Áo sơ mi nam trắng Việt Tiến", LanguageId = "vi-VN", SeoAlias = "ao-so-mi-nam-trang-viet-tien", SeoDescription = "Áo sơ mi nam trắng Việt Tiến", SeoTitle = "Áo sơ mi nam trắng Việt Tiến", Details = "Áo sơ mi nam trắng Việt Tiến", Description = "Áo sơ mi nam trắng Việt Tiến" },
                 new ProductTranslation() {Id = 2, ProductId = 1, Name = "Viet Tien Men T-Shirt", LanguageId = "en-US", SeoAlias = "viet-tien-men-t-shirt", SeoDescription = "Viet Tien Men T-Shirt", SeoTitle = "Viet Tien Men T-Shirt", Details = "Viet Tien Men T-Shirt", Description = "Viet Tien Men T-Shirt" }
             );
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() {ProductId = 1, CategoryId = 1}
            );


            // any guid
            var roleId = new Guid("719596CE-9596-438D-B4EF-1EDBCFA103B1");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "nguyenvantanst.2210@gmail.com",
                NormalizedEmail = "nguyenvantanst.2210@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "tan@0385294187"),
                SecurityStamp = string.Empty,
                FirstName = "Tan",
                LastName = "Nguyen",
                Dob = new DateTime(1999, 10, 22)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
