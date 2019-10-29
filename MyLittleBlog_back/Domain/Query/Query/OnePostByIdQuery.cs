using MyLittleBlog_back.Domain.Entity;
using PostDBManager.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Query.Query
{
    public class OnePostByIdQuery : IQuery<PostDTO>
    {
        public string ID { get; private set; }

        public OnePostByIdQuery (string id)
        {
            ID = id;
        }
    }
}
