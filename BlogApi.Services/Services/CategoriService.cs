using AutoMapper;
using BlogApi.Data.Dtos;
using BlogApi.Data.Entities;
using BlogApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApi.Services.Services
{
    public class CategoriService : ICategoriService
    {

        private readonly IRepository<Category> CategoryRepository;
        private IMapper mapper;
        public CategoriService(IRepository<Category> _categoryRepository, IMapper _mapper)
        {
            this.CategoryRepository = _categoryRepository;
            this.mapper = _mapper;
        }

        public bool Create(CategoryDto categoryDto)
        {
            var categori = mapper.Map<Category>(categoryDto);
            if (categori != null)
            {
                CategoryRepository.Add(categori);
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
                var entity = CategoryRepository.Find(s => s.Id == id);
                CategoryRepository.Delete(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public CategoryDto FindById(int id)
        {
            var categori = CategoryRepository.Find(s => s.Id == id);
            var userDtos = mapper.Map<CategoryDto>(categori);
            return userDtos;
        }

        public List<CategoryDto> GetList()
        {
            var categorilist = CategoryRepository.GetAll();
            var userDtos = mapper.Map<List<CategoryDto>>(categorilist);
            return userDtos;
        }

        public bool Update(CategoryDto categoryDto)
        {
            try
            {
                var categori = mapper.Map<Category>(categoryDto);
                CategoryRepository.Update(categori, categori);
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }
    }
}
