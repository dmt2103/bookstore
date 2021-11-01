using BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookStore.Repository.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new BookStoreContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreContext>>());

            if (context.Categories.Any())
            {
                return;   // DB has been seeded
            }

            context.Categories.AddRange(
                new Category
                {
                    CategoryName = "Action",
                    Description = "Action"
                },
                new Category
                {
                    CategoryName = "Comedy",
                    Description = "Comedy"
                },
                new Category
                {
                    CategoryName = "Horror",
                    Description = "Horror"
                },
                new Category
                {
                    CategoryName = "Sci-Fi",
                    Description = "Sci-Fi"
                }
            );

            context.Tags.AddRange(
                new Tag
                {
                    TagName = "Action Tag"
                },
                new Tag
                {
                    TagName = "Comedy Tag"
                }
            );

            context.SaveChanges();
        }
    }
}