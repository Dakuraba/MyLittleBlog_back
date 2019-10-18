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

namespace MyLittleBlog_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostCommandController : ControllerBase
    {
        [HttpPost("v1")]
        public async Task<IActionResult>  Post(Post item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiBadRequestResponse(ModelState));
            }

            var command = new SavePostCommand(item);
            var handler = PostCommandHandlerFactory.Build(command);
            var response = await handler.Execute();


            if (response.Success)
            {
                item.ID = response.ID;
                return Ok(item);
            }
            else
            {
                return BadRequest(new ApiResponse(500));
            }
        }

        [HttpPut("v1")]
        public async Task<IActionResult> Put(Post item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiBadRequestResponse(ModelState));
            }

            var command = new PutPostCommand(item);
            var handler = PostCommandHandlerFactory.Build(command);
            var response = await handler.Execute();


            if (response.Success)
            {
                item.ID = response.ID;
                return Ok(item);
            }
            else
            {
                return BadRequest(new ApiResponse(500));
            }
        }

        [HttpDelete]
        [Route("v1/posts/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiBadRequestResponse(ModelState));
            }

            var command = new DeletePostCommand(id);
            var handler = PostCommandHandlerFactory.Build(command);
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