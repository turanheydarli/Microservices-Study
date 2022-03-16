using ESourcing.Sourcing.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ESourcing.Sourcings.Entities
{
    public class Auction : IEntity
    {
        public Auction()
        {
            IncludedSellers = new List<string>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }
        public List<string> IncludedSellers { get; set; }
    }

    public enum AuctionStatus
    {
        Active = 0,
        Closed = 1,
        Passive = 2
    }
}
