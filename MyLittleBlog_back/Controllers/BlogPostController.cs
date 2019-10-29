using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLittleBlog_back.Domain.Command;
using MyLittleBlog_back.Domain.Command.Command;
using MyLittleBlog_back.Domain.Entity;
using MyLittleBlog_back.Domain.Query;
using MyLittleBlog_back.Domain.Query.Query;
using MyLittleBlog_back.Utils;

namespace MyLittleBlog_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {

        private readonly IPostQueryHandlerFactory _queryFactory;

        public BlogPostController(IPostQueryHandlerFactory queryFactory)
        {
            _queryFactory = queryFactory;
        }

        /// <summary>
        /// Get method. Retrive all post from database ordered by postdate.
        /// </summary>
        /// <returns></returns>
        [HttpGet("v1")]
        public async Task<IActionResult> GetAll()
        {
            var query = new AllPostQuery();
            var handler = _queryFactory.Build(query);
            var postList = await handler.Get();
            
            return Ok(postList); 
        }


        /// <summary>
        /// Get method. Retrieve post of id passed in parameter.
        /// </summary>
        /// <param name="id">id of the requested post</param>
        /// <returns></returns>
        [HttpGet("v1/{id}")]
        public async Task<IActionResult> GetPost(string id)
        {
            var query = new OnePostByIdQuery(id);
            var handler = _queryFactory.Build(query);
            var post = await handler.Get();

            return Ok(post);
        }
    }
}