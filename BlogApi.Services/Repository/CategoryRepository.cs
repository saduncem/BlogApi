using BlogApi.Domain.Context;
using BlogApi.Domain.Dtos;
using BlogApi.Domain.Entities;
using BlogApi.Domain.Interfaces;
using BlogApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogApi.Services.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        readonly BlogContext _blogContext;
        public CategoryRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }
        public void Add(Category entity)
        {
            _blogContext.Category.Add(entity);
            _blogContext.SaveChanges();
        }

        public void Delete(Category entity)
        {
             _blogContext.Category.Remove(entity);
            _blogContext.SaveChanges();
        }

        public Category Find(Expression<Func<Category, bool>> where)
        {
            return _blogContext.Category.Where(where).FirstOrDefault();
        }

        public IEnumerable<Category> FindAll(Expression<Func<Category, bool>> where)
        {
            return _blogContext.Category.Where(where);
        }

        public Category Get(long id)
        {
            var author = _blogContext.Category
               .SingleOrDefault(b => b.Id == id);

            return author;
        }

        public IEnumerable<Category> GetAll()
        {
            return _blogContext.Category
              .Include(author => author.Post)
              .ToList();
        }

        public Category GetDto(long id)
        {
            _blogContext.ChangeTracker.LazyLoadingEnabled = true;
            return _blogContext.Category.Find(id);
           
        }

        public void Update(Category entityToUpdate, Category entity)
        {
            _blogContext.Category.Update(entityToUpdate);
            _blogContext.SaveChanges();
        }
    }
}
