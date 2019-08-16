using BlogApi.Domain.Dtos;
using BlogApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApi.Services.Interfaces
{
    public interface IPostService : IBaseService<Post, PostDto>
    {

        //List<PostDto> GetPostList();
        //List<Post> GetList();
        //Post FindById(int CategoriId);
        //Post CreatePost(PostDto categoryDto);
        //bool Delete(PostDto categoryDto);
        //bool Update(PostDto categoryDto);
    }
}
