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
        // GET api/values
        [HttpGet]
        [Route("v1/posts")]
        public IEnumerable<Post> GetAll()
        {
            var query = new AllPostQuery();
            var handler = PostQueryHandlerFactory.Build(query);
            return handler.Get(); 
        }

        [HttpGet]
        [Route("v1/posts/{id}")]
        public Post GetPost(int id)
        {
            var query = new OnePostByIdQuery(id);
            var handler = PostQueryHandlerFactory.Build(query);

            return handler.Get();
        }
    }
}