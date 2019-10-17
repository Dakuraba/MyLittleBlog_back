using MyLittleBlog_back.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain
{
    public static class MockBlogDb
    {
        public static IList<Post> Posts { get; }
        public static int UniquePostId = 4;

        static MockBlogDb()
        {
            Posts = new List<Post>()
            {
                new Post { ID = 1, PostContent = "Mock Content 1", PostTitle = "Mock title 1", PostDate ="10/10/19" },
                new Post { ID = 1, PostContent = "Mock Content 2", PostTitle = "Mock title 2", PostDate ="11/10/19" },
                new Post { ID = 1, PostContent = "Mock Content 3", PostTitle = "Mock title 3", PostDate ="12/10/19" },
            };
        }
    }
}
