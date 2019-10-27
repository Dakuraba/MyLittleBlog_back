using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
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
    public class AllPostQueryHandler : IQueryHandler<AllPostQuery, IEnumerable<PostDTO>>
    {
        private readonly IPostsRepository _repo;

        public AllPostQueryHandler([FromServices] IPostsRepository repo)
        {
            _repo = repo;
        }


        public async Task<IEnumerable<PostDTO>> Get()
        {
            return await _repo.SelectAllAsync();
        }
    }
}
