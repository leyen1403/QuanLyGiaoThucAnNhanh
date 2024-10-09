using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DAL
{
    public class MongoDB_DAL        
    {
        string connectionString = "mongodb://localhost:27017";
        string databaseName = "DoAnNoSQL_GiaoThucAnNhanh";
        private readonly IMongoDatabase _database;

        public MongoDB_DAL()
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }
        public IMongoCollection<BsonDocument> GetCollection(string collectionName)
        {
            return _database.GetCollection<BsonDocument>(collectionName);
        }

        public void Insert(string collectionName, BsonDocument document)
        {
            var collection = this.GetCollection(collectionName);
            collection.InsertOne(document);
        }
        public BsonDocument GetOneCuaHang(string maCuaHang, string matKhau)
        {
            var collection = this.GetCollection("CuaHangGiaoThucAnNhanh");
            var filter = Builders<BsonDocument>.Filter.Eq("ma_cua_hang", maCuaHang) & Builders<BsonDocument>.Filter.Eq("mat_khau_dang_nhap", matKhau);
            return collection.Find(filter).FirstOrDefault();
        }
    }
}
