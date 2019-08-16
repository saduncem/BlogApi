using AutoMapper;
using BlogApi.Data.Dtos;
using BlogApi.Data.Entities;
using BlogApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace BlogApi.Services.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comments> CommentsRepository;
        private IMapper mapper;
        public CommentsService(IRepository<Comments> _commentRepository, IMapper _mapper)
        {
            this.CommentsRepository = _commentRepository;
            this.mapper = _mapper;
        }

        public bool Create(CommentsDto commentsDto)
        {
            var post = mapper.Map<Comments>(commentsDto);
            if (post != null)
            {
                CommentsRepository.Add(post);
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
                var entity = CommentsRepository.Find(s => s.Id == id);
                CommentsRepository.Delete(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public CommentsDto FindById(int id)
        {
            var post = CommentsRepository.Find(s => s.Id == id);
            var userDtos = mapper.Map<CommentsDto>(post);
            return userDtos;
        }

        public List<CommentsDto> GetList()
        {
            var Commentlist = CommentsRepository.GetAll();
            var userDtos = mapper.Map<List<CommentsDto>>(Commentlist);
            return userDtos;
        }

        public bool Update(CommentsDto postdto)
        {
            try
            {
                var postmodel = mapper.Map<Comments>(postdto);
                CommentsRepository.Update(postmodel, postmodel);
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }
    }
}
