using MyLittleBlog_back.Domain.Entity;
using MyLittleBlog_back.Domain.Query.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Query.Handler
{
    public class OnePostByIdQueryHandler : IQueryHandler<OnePostByIdQuery, Post>
    {
        private readonly OnePostByIdQuery _query;

        public OnePostByIdQueryHandler(OnePostByIdQuery query)
        {
            _query = query;
        }
        
        public Post Get()
        {
            return MockBlogDb.Posts.FirstOrDefault(p => p.ID == _query.ID);
        }
    }
}
