using MyLittleBlog_back.Domain.Entity;
using MyLittleBlog_back.Domain.Query.Handler;
using MyLittleBlog_back.Domain.Query.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Query
{
    public static class PostQueryHandlerFactory
    {
        public static IQueryHandler<AllPostQuery, IEnumerable<Post>> Build(AllPostQuery query)
        {
            return new AllPostQueryHandler();
        }

        public static IQueryHandler<OnePostByIdQuery, Post> Build(OnePostByIdQuery query)
        {
            return new OnePostByIdQueryHandler(query);
        }            
    }
}
