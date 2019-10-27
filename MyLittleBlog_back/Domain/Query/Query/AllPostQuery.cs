using MyLittleBlog_back.Domain.Entity;
using PostDBManager.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Query.Query
{
    public class AllPostQuery : IQuery<IEnumerable<PostDTO>>
    {
    }
}
