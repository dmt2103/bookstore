using BookStore.Domain.Models;
using BookStore.Repository.Data;
using BookStore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Repository.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookStoreContext _context;

        public CategoryRepository(BookStoreContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            var listCategory = _context.Categories.ToList();
            return listCategory;
        }

        public Category CreateCategory(Category category)
        {
            category.CategoryId = Guid.NewGuid();
            _context.Add(category);
            _context.SaveChanges();

            return category;
        }

        public Category GetCategory(Guid? categoryId)
        {
            if (categoryId == null)
            {
                return null;
            }

            var category = _context.Categories.Find(categoryId);
            if (category == null)
            {
                return null;
            }

            return category;
        }

        public Category UpdateCategory(Category category)
        {
            _context.Update(category);
            _context.SaveChanges();

            return category;
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}