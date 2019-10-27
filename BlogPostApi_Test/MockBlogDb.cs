using PostDBManager.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain
{
    public static class MockBlogDb 
    {
        public static IList<PostDTO> Posts { get; }
        public static int UniquePostId = 4;

        static MockBlogDb()
        {
            Posts = new List<PostDTO>()
            {
                new PostDTO { PostId = 1, PostContent = "Mock Content 1", PostTitle = "Mock title 1", PostDate ="10/10/19", _id = new MongoDB.Bson.ObjectId()},
                new PostDTO { PostId = 2, PostContent = "Mock Content 2", PostTitle = "Mock title 2", PostDate ="11/10/19", _id = new MongoDB.Bson.ObjectId() },
                new PostDTO { PostId = 3, PostContent = "Mock Content 3", PostTitle = "Mock title 3", PostDate ="12/10/19" , _id = new MongoDB.Bson.ObjectId()},
            };
        }
    }
}
