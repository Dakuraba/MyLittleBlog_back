using Microsoft.AspNetCore.Mvc;
using MyLittleBlog_back.Domain.Entity;
using MyLittleBlog_back.Domain.Query.Query;
using PostDBManager.DTOs;
using PostDBManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Query.Handler
{
    public class OnePostByIdQueryHandler : IQueryHandler<OnePostByIdQuery, PostDTO>
    {
        private readonly OnePostByIdQuery _query;
        private readonly IPostsRepository _repo;

        public OnePostByIdQueryHandler([FromServices] IPostsRepository repo, OnePostByIdQuery query)
        {
            _query = query;
            _repo = repo;
        }
        
        public async Task<PostDTO> Get()
        {
            return await _repo.GetAsync(_query.ID.ToString());
        }
    }
}
