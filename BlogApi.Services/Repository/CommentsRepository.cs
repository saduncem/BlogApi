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
    public class CommentsRepository : IRepository<Comments>
    {
        readonly BlogContext _blogContext;
        public CommentsRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }
        public void Add(Comments entity)
        {
            _blogContext.Comments.Add(entity);
            _blogContext.SaveChanges();
        }

        public void Delete(Comments entity)
        {
            _blogContext.Comments.Remove(entity);
            _blogContext.SaveChanges();
        }

        public Comments Find(Expression<Func<Comments, bool>> where)
        {
            return _blogContext.Comments.Where(where).FirstOrDefault();
        }

        public IEnumerable<Comments> FindAll(Expression<Func<Comments, bool>> where)
        {
            return _blogContext.Comments.Where(where);
        }

        public Comments Get(long id)
        {
            var comments = _blogContext.Comments
               .SingleOrDefault(b => b.Id == id);

            return comments;
        }

        public IEnumerable<Comments> GetAll()
        {
            return _blogContext.Comments
              .ToList();
        }

        public Comments GetDto(long id)
        {
            _blogContext.ChangeTracker.LazyLoadingEnabled = true;
            return _blogContext.Comments.Find(id);
           
        }

        public void Update(Comments entityToUpdate, Comments entity)
        {
            _blogContext.Comments.Update(entityToUpdate);
            _blogContext.SaveChanges();
        }
    }
}
