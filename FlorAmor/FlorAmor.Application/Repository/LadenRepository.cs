using System;
using System.Collections.Generic;
using MongoDB.Driver;
using FlorAmor.Application.Model;
using FlorAmor.Application.Data;

namespace FlorAmor.Application.Repository
{
    public class LadenRepository
    {
        private readonly IMongoCollection<Laden> _laeden;

        public LadenRepository(MongoDBContext context)
        {
            _laeden = context.Laden;
        }

        public void Add(Laden laden)
        {
            _laeden.InsertOne(laden);
        }

        public List<Laden> GetAll()
        {
            return _laeden.Find(laden => true).ToList();
        }

        public Laden GetById(Guid id)
        {
            return _laeden.Find<Laden>(laden => laden.Id == id).FirstOrDefault();
        }

        public void DeleteAll()
        {
            _laeden.DeleteMany(laden => true);
        }
    }
}