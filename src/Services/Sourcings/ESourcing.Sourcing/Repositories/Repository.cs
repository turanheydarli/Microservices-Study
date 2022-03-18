using ESourcing.Sourcing.Data.Interfaces;
using ESourcing.Sourcing.Repositories.Interfaces;
using ESourcing.Sourcings.Entities;
using ESourcing.Sourcings.Settings.Interfaces;
using MongoDB.Driver;

namespace ESourcing.Sourcing.Repositories
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        protected IMongoCollection<T> Collection { get; }

        public Repository(ISourcingDatabaseSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            Collection = database.GetCollection<T>(nameof(T));
        }

        public async Task Create(T entity)
        {
            await Collection.InsertOneAsync(entity);
        }

        public async Task<bool> Delete(string id)
        {
            var deleteResult = await Collection.DeleteOneAsync(a => a.Id == id);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Collection.Find(a => true).ToListAsync();
        }

        public async Task<T> Get(string id)
        {
            return await Collection.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(T entity)
        {
            var updateResult = await Collection.ReplaceOneAsync(a => a.Id == entity.Id, entity);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;

        }
    }
}
