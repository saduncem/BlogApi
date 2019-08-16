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
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;


        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }


        // GET: api/Comments
        [HttpGet]
        public IActionResult GetComments()
        {
            var data = _commentsService.GetList();
            return Ok(data);
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public IActionResult GetComments(int id)
        {
            var comments = _commentsService.FindById(id);

            if (comments == null)
            {
                return NotFound();
            }
            return Ok(comments);
        }

      

        // POST: api/Comments
        [HttpPost]
        public IActionResult PostComments([FromForm] CommentsDto comments)
        {
            try
            {
                var result = _commentsService.Create(comments);
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

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public IActionResult DeleteComments(int id)
        {
            var comments = _commentsService.FindById(id);
            if (comments == null)
            {
                return NotFound();
            }
            return Ok(comments);

           
        }

    }
}
