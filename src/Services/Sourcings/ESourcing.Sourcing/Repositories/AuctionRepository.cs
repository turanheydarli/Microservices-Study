using ESourcing.Sourcing.Data.Interfaces;
using ESourcing.Sourcing.Repositories.Interfaces;
using ESourcing.Sourcings.Entities;
using ESourcing.Sourcings.Settings.Interfaces;
using MongoDB.Driver;

namespace ESourcing.Sourcing.Repositories
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly IMongoCollection<T> _collection;

        public Repository(ISourcingDatabaseSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<T>(nameof(T));
        }

        public async Task Create(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task<bool> Delete(string id)
        {
            var deleteResult = await _collection.DeleteOneAsync(a => a.Id == id);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _collection.Find(a => true).ToListAsync();
        }

        public async Task<T> Get(string id)
        {
            return await _collection.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(T entity)
        {
            var updateResult = await _collection.ReplaceOneAsync(a => a.Id == entity.Id, entity);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;

        }
    }
}
