using PostDBManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Command.Handler
{
    public abstract class BasePostRepository
    {
        protected readonly IPostsRepository _repo;

        public BasePostRepository(IPostsRepository repo)
        {
            _repo = repo;
        }
    }
}
