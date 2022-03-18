using ESourcing.Sourcing.Repositories.Interfaces;
using ESourcing.Sourcings.Entities;
using ESourcing.Sourcings.Settings;
using MongoDB.Driver;
using System.Linq;

namespace ESourcing.Sourcing.Repositories
{
    public class BidRepository : Repository<Bid>, IBidRepository
    {
        public BidRepository(SourcingDatabaseSettings settings) : base(settings) { }

        public async Task<List<Bid>> GetBidsByAuctionId(string id)
        {
            List<Bid> bids = await Collection.Find(b => b.AucationId == id).ToListAsync();

            bids = bids.OrderByDescending(b => b.CreatedAt).GroupBy(b => b.SellerName).Select(s =>
                new Bid
                {
                    AucationId = s.FirstOrDefault().AucationId,
                    Price = s.FirstOrDefault().Price,
                    CreatedAt = s.FirstOrDefault().CreatedAt,
                    SellerName = s.FirstOrDefault().SellerName,
                    ProductId = s.FirstOrDefault().ProductId,
                    Id = s.FirstOrDefault().Id
                }).ToList();

            return bids;
        }

        public async Task<Bid> GetWinnerBid(string id)
        {
            List<Bid> bids = await GetBidsByAuctionId(id);

            return bids.OrderByDescending(b => b.Price).FirstOrDefault();
        }

        public async Task SendBid(Bid bid)
        {
            await Collection.InsertOneAsync(bid);
        }
    }
}
