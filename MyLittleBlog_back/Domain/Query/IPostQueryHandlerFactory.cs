using System.Collections.Generic;
using MyLittleBlog_back.Domain.Query.Handler;
using MyLittleBlog_back.Domain.Query.Query;
using PostDBManager.DTOs;

namespace MyLittleBlog_back.Domain.Query
{
    public interface IPostQueryHandlerFactory
    {
        IQueryHandler<AllPostQuery, IEnumerable<PostDTO>> Build(AllPostQuery query);
        IQueryHandler<OnePostByIdQuery, PostDTO> Build(OnePostByIdQuery query);
    }
}