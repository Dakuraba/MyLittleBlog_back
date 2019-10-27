using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PostDBManager.DTOs;
using PostDBManager.Interface;

namespace PostDBManager.Repository
{
    public class PostsRepository : IPostsRepository
    {

        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected IMongoCollection<PostDTO> _collection;

        public PostsRepository()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("blogdb");
            _collection = _database.GetCollection<PostDTO>("post");
        }

        public async Task<PostDTO> InsertPostAsync(PostDTO contact)
        {
            await this._collection.InsertOneAsync(contact);
            return await this.GetAsync(contact._id.ToString());
        }

        public async Task<IEnumerable<PostDTO>> SelectAllAsync()
        {
            return await this._collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<IEnumerable<PostDTO>> FilterAsync(string jsonQuery)
        {
            var queryDoc = new BsonDocument(BsonSerializer.Deserialize<BsonDocument>(jsonQuery));
            var dbresult = await _collection.FindAsync<PostDTO>(queryDoc);
            return await dbresult.ToListAsync();
        }

        public async Task<PostDTO> GetAsync(string id)
        {
            return await this._collection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).FirstAsync();
        }

        public async Task<PostDTO> UpdatePostAsync(string id, PostDTO post)
        {
            post._id = new ObjectId(id);

            var filter = Builders<PostDTO>.Filter.Eq(s => s._id, post._id);
            await this._collection.ReplaceOneAsync(filter, post);
            return await this.GetAsync(id);
        }

        public async Task DeletePostAsync(string id)
        {
            var _id = new ObjectId(id);

            var filter = Builders<PostDTO>.Filter.Eq(s => s._id, _id);
            await this._collection.DeleteOneAsync(filter);
        }
    }
}
