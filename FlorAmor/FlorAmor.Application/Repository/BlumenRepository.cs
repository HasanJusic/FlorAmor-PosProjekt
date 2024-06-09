using MongoDB.Driver;
using FlorAmor.Application.Model;
using FlorAmor.Application.Data;

namespace FlorAmor.Application.Repository
{
    public class BlumenRepository
    {
        private readonly IMongoCollection<Blume> _blumen;

        public BlumenRepository(MongoDBContext context)
        {
            _blumen = context.Blumen;
        }

        public void Add(Blume blume)
        {
            _blumen.InsertOne(blume);
        }

        public List<Blume> GetAll()
        {
            return _blumen.Find(blume => true).ToList();
        }

        public Blume GetById(Guid id)
        {
            return _blumen.Find(blume => blume.Id == id).FirstOrDefault();
        }

        public void DeleteAll()
        {
            _blumen.DeleteMany(blume => true);
        }

        public async Task<bool> DeleteBlumenById(Guid blumenId)
        {
            var deleteResult = await _blumen.DeleteOneAsync(x => x.Id == blumenId);
            return deleteResult.DeletedCount > 0;
        }

        public void Update(Blume blume)
        {
            var filter = Builders<Blume>.Filter.Eq(b => b.Id, blume.Id);
            _blumen.ReplaceOne(filter, blume);
        }

      
    }
}
