using BlogApi.Domain.Dtos;
using BlogApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApi.Services.Interfaces
{
    public interface ICategoriService : IBaseService<Category, CategoryDto>
    {
        //List<CategoryDto> GetCategoriList();
        //CategoryDto FindById(int CategoriId);
        //bool Create(CategoryDto categoryDto);
        //bool Delete(int categoriid);
        //bool Update(CategoryDto categoryDto);
    }
}
