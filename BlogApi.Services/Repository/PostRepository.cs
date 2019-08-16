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
    public class PostRepository : IRepository<Post>
    {
        readonly BlogContext _blogContext;
        public PostRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }
        public void Add(Post entity)
        {
            _blogContext.Post.Add(entity);
            _blogContext.SaveChanges();
        }

        public void Delete(Post entity)
        {
             _blogContext.Post.Remove(entity);
            _blogContext.SaveChanges();
        }

        public Post Find(Expression<Func<Post, bool>> where)
        {
            return _blogContext.Post.Where(where).FirstOrDefault();
        }

        public IEnumerable<Post> FindAll(Expression<Func<Post, bool>> where)
        {
            return _blogContext.Post.Where(where);
        }

        public Post Get(long id)
        {
            var author = _blogContext.Post
               .SingleOrDefault(b => b.Id == id);

            return author;
        }

        public IEnumerable<Post> GetAll()
        {
            return _blogContext.Post
              .Include(Comments => Comments.Comments)
              .Include(Tag => Tag.Tag)
              .Include(cat => cat.Category)
              .ToList();
        }

        public Post GetDto(long id)
        {
            _blogContext.ChangeTracker.LazyLoadingEnabled = true;
            return _blogContext.Post.Find(id);
           
        }

        public void Update(Post entityToUpdate, Post entity)
        {
            _blogContext.Post.Update(entityToUpdate);
            _blogContext.SaveChanges();
        }
    }
}
