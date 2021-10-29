using BookStore.Domain.Models;
using BookStore.Repository.Data;
using BookStore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Repository.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BookStoreContext _context;

        public TagRepository(BookStoreContext context)
        {
            _context = context;
        }

        public List<Tag> GetAllTags(string searchString)
        {
            var listTag = from t in _context.Tags select t;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                listTag = listTag.Where(c => c.TagName.Contains(searchString));
            }

            return listTag.ToList();
        }

        public Tag CreateTag(Tag tag)
        {
            tag.TagId = Guid.NewGuid();
            _context.Add(tag);
            _context.SaveChanges();

            return tag;
        }

        public Tag GetTag(Guid? tagId)
        {
            if (tagId == null)
            {
                return null;
            }

            var tag = _context.Tags.Find(tagId);

            return tag;
        }
    }
}