using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Entity
{
    public class Post
    {
        public int ID { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PostDate { get; set; }
    }
}

