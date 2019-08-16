using BlogApi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApi.Domain.Dtos
{
    public class CategoryDto 
    {

        public CategoryDto()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
