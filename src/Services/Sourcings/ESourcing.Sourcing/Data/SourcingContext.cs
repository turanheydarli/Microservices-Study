using ESourcing.Sourcing.Data.Interfaces;
using ESourcing.Sourcings.Entities;
using ESourcing.Sourcings.Settings.Interfaces;
using MongoDB.Driver;

namespace ESourcing.Sourcing.Data
{
    public class SourcingContext: ISourcingContext
    {
        public SourcingContext(ISourcingDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            Auctions = database.GetCollection<Auction>(nameof(Auction));
            Bids = database.GetCollection<Bid>(nameof(Bid));

            SourcingContextSeed.SeedData(Auctions, Bids);
        }

        public IMongoCollection<Auction> Auctions { get; }
        public IMongoCollection<Bid> Bids { get; }
    }
}
