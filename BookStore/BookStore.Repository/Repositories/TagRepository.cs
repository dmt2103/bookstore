using BookStore.Contract.RequestModels;
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

        public Tag CreateTag(TagRequestModel request)
        {
            var tag = new Tag
            {
                TagId = Guid.NewGuid(),
                TagName = request.TagName
            };

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

        public List<Tag> GetTagsByBookId(Guid? bookId)
        {
            if (bookId == null)
            {
                return null;
            }

            var tags = (from tag in _context.Tags
                        join bookTag in _context.BookTags
                            on tag.TagId equals bookTag.TagId
                        where bookTag.BookId.Equals(bookId)
                        select new Tag()
                        {
                            TagId = tag.TagId,
                            TagName = tag.TagName
                        }).ToList();

            return tags;
        }

        public void DeleteTag(Guid? tagId)
        {
            var tag = GetTag(tagId);
            if (tag == null) return;
            _context.Tags.Remove(tag);
            _context.SaveChanges();
        }
    }
}