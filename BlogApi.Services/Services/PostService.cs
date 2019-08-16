using AutoMapper;
using BlogApi.Domain.Dtos;
using BlogApi.Domain.Entities;
using BlogApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace BlogApi.Services.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> PostRepository;
        private IMapper mapper;
        public PostService(IRepository<Post> _postRepository, IMapper _mapper)
        {
            this.PostRepository = _postRepository;
            this.mapper = _mapper;
        }

        public bool Create(PostDto postDto)
        {
            var post = mapper.Map<Post>(postDto);
            if (post != null)
            {
                PostRepository.Add(post);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = PostRepository.Find(s => s.Id == id);
                PostRepository.Delete(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public PostDto FindById(int id)
        {
            var post = PostRepository.Find(s => s.Id == id);
            var userDtos = mapper.Map<PostDto>(post);
            return userDtos;
        }

        public List<PostDto> GetList()
        {
            var postlist = PostRepository.GetAll();
            var userDtos = mapper.Map<List<PostDto>>(postlist);
            return userDtos;
        }

        public bool Update(PostDto postdto)
        {
            try
            {
                var postmodel = mapper.Map<Post>(postdto);
                PostRepository.Update(postmodel, postmodel);
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }
    }
}
