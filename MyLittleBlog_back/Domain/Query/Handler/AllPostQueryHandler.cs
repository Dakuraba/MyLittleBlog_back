using MyLittleBlog_back.Domain.Entity;
using MyLittleBlog_back.Domain.Query.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Query.Handler
{
    public class AllPostQueryHandler : IQueryHandler<AllPostQuery, IEnumerable<Post>>
    {
        public async Task<IEnumerable<Post>> Get()
        {
            return MockBlogDb.Posts.OrderBy(p => p.ID);
        }
    }
}
