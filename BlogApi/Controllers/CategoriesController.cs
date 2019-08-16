using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogApi.Domain.Context;
using BlogApi.Domain.Entities;
using BlogApi.Services.Interfaces;
using BlogApi.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace BlogApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriService _categoriService;
        public CategoriesController(ICategoriService categoriService)
        {
            _categoriService = categoriService;
        }

        // GET: api/Categories
        [HttpGet]
        public IActionResult GetCategory()
        {
            var data = _categoriService.GetList();
            return Ok(data);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _categoriService.FindById(id);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

      
        [HttpPost]
        public IActionResult PostCategory([FromForm] CategoryDto category)
        {
            var result = _categoriService.Create(category);
            if (result)
            {
                return RedirectToAction("GetCategory");
            }
            return Ok( new { Message = "Error" });
           
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = CategoryExists(id);
            if (category)
            {
                _categoriService.Delete(id);
                return Ok();
            }
            return NotFound();
           
        }

        private bool CategoryExists(int id)
        {
            var category = _categoriService.FindById(id);
            if (category == null)
            {
                return false;
            }
            return true;
        }
    }
}
