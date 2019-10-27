using Microsoft.Extensions.DependencyInjection;
using MyLittleBlog_back.Domain.Entity;
using MyLittleBlog_back.Domain.Query.Handler;
using MyLittleBlog_back.Domain.Query.Query;
using PostDBManager.DTOs;
using PostDBManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Query
{
    public class PostQueryHandlerFactory : IPostQueryHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PostQueryHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public IQueryHandler<AllPostQuery, IEnumerable<PostDTO>> Build(AllPostQuery query)
        {
            return new AllPostQueryHandler(_serviceProvider.GetService<IPostsRepository>());
        }

        public IQueryHandler<OnePostByIdQuery, PostDTO> Build(OnePostByIdQuery query)
        {
            return new OnePostByIdQueryHandler(_serviceProvider.GetService<IPostsRepository>(), query);
        }            
    }
}
