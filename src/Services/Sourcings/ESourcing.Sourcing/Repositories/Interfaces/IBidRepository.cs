using ESourcing.Sourcings.Entities;

namespace ESourcing.Sourcing.Repositories.Interfaces
{
    public interface IBidRepository : IRepository<Bid>
    {
        Task SendBid(Bid bid);
        Task<List<Bid>> GetBidsByAuctionId(string id);
         
    }
}
