using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostDBManager.DTOs
{
    public class CountersDTO
    {
        [BsonElement("_id")]
        public int Id { get; set; }
        [BsonElement("sequence_value")]
        public int SequenceValue { get; set; }
    }
}
