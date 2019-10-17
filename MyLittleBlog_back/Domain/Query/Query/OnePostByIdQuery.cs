using MyLittleBlog_back.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Query.Query
{
    public class OnePostByIdQuery : IQuery<Post>
    {
        public int ID { get; private set; }

        public OnePostByIdQuery (int id)
        {
            ID = id;
        }
    }
}
