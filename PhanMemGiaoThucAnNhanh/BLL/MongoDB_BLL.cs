﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BLL
{
    public class MongoDB_BLL
    {
        MongoDB_DAL dal = new MongoDB_DAL();
        public IMongoCollection<BsonDocument> GetAllDocuments(string collectionName)
        {
            return dal.GetCollection(collectionName);
        }

        public void AddDocument(string collectionName, BsonDocument document)
        {
            dal.Insert(collectionName, document);
        }
        public BsonDocument GetOneCuaHang(string maCuaHang, string matKhau)
        {            
            return dal.GetOneCuaHang(maCuaHang, matKhau);
        }
    }
}
