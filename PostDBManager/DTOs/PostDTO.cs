using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PostDBManager.DTOs
{
    public class PostDTO
    {
        public ObjectId _id { get; set; }
        [BsonElement("PostId")]
        public int PostId { get; set; }
        [BsonElement("PostTitle")]
        public string PostTitle { get; set; }
        [BsonElement("PostContent")]
        public string PostContent { get; set; }
        [BsonElement("PostDate")]
        public string PostDate { get; set; }
    }
}
