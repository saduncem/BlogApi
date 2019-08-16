using BlogApi.Data.Dtos;
using BlogApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApi.Services.Interfaces
{
    public interface ICommentsService : IBaseService<Comments, CommentsDto>
    {

        //List<PostDto> GetPostList();
        //List<Post> GetList();
        //Post FindById(int CategoriId);
        //Post CreatePost(PostDto categoryDto);
        //bool Delete(PostDto categoryDto);
        //bool Update(PostDto categoryDto);
    }
}
