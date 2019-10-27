using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLittleBlog_back.Domain.Command;
using MyLittleBlog_back.Domain.Command.Command;
using MyLittleBlog_back.Domain.Entity;
using MyLittleBlog_back.Utils;
using PostDBManager.DTOs;

namespace MyLittleBlog_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostCommandController : ControllerBase
    {
        private readonly IPostCommandHandlerFactory _factory;

        public BlogPostCommandController(IPostCommandHandlerFactory factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Post method to save a new post to the database.
        /// </summary>
        /// <param name="item">the post to save</param>
        /// <returns></returns>
        [HttpPost("v1")]
        public async Task<IActionResult>  Post(PostDTO item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiBadRequestResponse(ModelState));
            }

            var command = new SavePostCommand(item);
            var handler = _factory.Build(command);
            var response = await handler.Execute();


            if (response.Success)
            {
                item.PostId = response.ID;
                return Ok(item);
            }
            else
            {
                return BadRequest(new ApiResponse(500));
            }
        }

        /// <summary>
        /// Put method. Update the item passed in pamareter
        /// </summary>
        /// <param name="item">the post to update</param>
        /// <returns></returns>
        [HttpPut("v1")]
        public async Task<IActionResult> Put(PostDTO item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiBadRequestResponse(ModelState));
            }

            var command = new PutPostCommand(item);
            var handler = _factory.Build(command);
            var response = await handler.Execute();


            if (response.Success)
            {
                item.PostId = response.ID;
                return Ok(item);
            }
            else
            {
                return BadRequest(new ApiResponse(500));
            }
        }

        /// <summary>
        /// Delete method. delete the item with id passed in parameter
        /// </summary>
        /// <param name="id">id of the post to delete</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("v1/posts/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiBadRequestResponse(ModelState));
            }

            var command = new DeletePostCommand(id);
            var handler = _factory.Build(command);
            var response = await handler.Execute();

            if (response.Success)
            {
                return Ok(id);
            }
            else
            {
                return BadRequest(new ApiResponse(500));
            }
        }
    }
}