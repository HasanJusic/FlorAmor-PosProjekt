﻿using FlorAmor.Application.Model;
using MongoDB.Driver;
using System;

namespace FlorAmor.Application.Data
{
    public class MongoDBContext
    {
        public readonly IMongoDatabase _database;

        public MongoDBContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
        public IMongoCollection<Laden> Laden => _database.GetCollection<Laden>("laden");
        public IMongoCollection<Blume> Blumen => _database.GetCollection<Blume>("blumen");
    }
}