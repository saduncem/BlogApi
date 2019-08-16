using BlogApi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApi.Data.Dtos
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
