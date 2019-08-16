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
    public class PostsController : ControllerBase
    {
        private readonly BlogContext _context;
        private readonly IPostService postService;

        public PostsController(BlogContext context, IPostService _postService)
        {
            _context = context;
            postService = _postService;
        }

        // GET: api/Posts
        [HttpGet]
        public IActionResult GetPost()
        {
            var data = postService.GetList();
            return Ok(data);
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            var post = postService.FindById(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // POST: api/Posts
        [HttpPost]
        public IActionResult PostPost([FromForm]  PostDto post)
        {
            try
            {
                var result = postService.Create(post);
                if (result)
                {
                    return RedirectToAction("GetPost");
                }
                return Ok(new { Message = "Error" });
            }
            catch (DbUpdateConcurrencyException)
            {
                return Ok(new { Message = "Error" });
            }
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public  IActionResult DeletePost(int id)
        {
            var result = postService.Delete(id);
            if (result)
            {
                return Ok(new { Message = "Success" });
            }

            return Ok(new { Message = "Error" });
        }

    }
}
