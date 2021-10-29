using BookStore.Contract.RequestModels;
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

        public List<Category> GetAllCategories(string searchString)
        {
            var listCategory = from c in _context.Categories select c;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                listCategory = listCategory.Where(c => c.CategoryName.Contains(searchString));
            }

            return listCategory.ToList();
        }

        public Category CreateCategory(CategoryRequestModel request)
        {
            var newCategory = new Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = request.CategoryName,
                Description = request.Description
            };

            _context.Add(newCategory);
            _context.SaveChanges();

            return newCategory;
        }

        public Category GetCategory(Guid? categoryId)
        {
            if (categoryId == null)
            {
                return null;
            }

            var category = _context.Categories.Find(categoryId);

            return category;
        }

        public Category UpdateCategory(CategoryRequestModel request)
        {
            var category = GetCategory(request.CategoryId);

            if (category == null)
            {
                return null;
            }

            category.CategoryName = request.CategoryName;
            category.Description = request.Description;

            _context.Update(category);
            _context.SaveChanges();

            return category;
        }

        public void DeleteCategory(Guid? categoryId)
        {
            var category = GetCategory(categoryId);
            if (category == null) return;
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}