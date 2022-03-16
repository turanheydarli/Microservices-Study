using ESourcing.Sourcings.Entities;
using MongoDB.Driver;

namespace ESourcing.Sourcing.Data
{
    public static class SourcingContextSeed
    {
        public static void SeedData(IMongoCollection<Auction> auctions, IMongoCollection<Bid> bids)
        {
            bool auctionsExist = auctions.Find(a => true).Any();
            bool bidsExist = bids.Find(a => true).Any();

            if (!auctionsExist)
                auctions.InsertMany(CustomizedAuctions());

            if (!bidsExist)
                bids.InsertMany(CustomizedBids());

        }

        private static IEnumerable<Auction> CustomizedAuctions()
        {
            return new List<Auction>
            {
                new Auction()
                {
                    Name = "Auction 1",
                    Description = "Auction description",
                    IncludedSellers = new List<string>
                    {
                        "testseler1@vaz.az",
                        "testseler2@vaz.az",
                        "testseler3@vaz.az"
                    },
                    Status = (int)AuctionStatus.Active,
                    Quantity = 100,
                    StartedAt = DateTime.Now,
                    FinishedAt = DateTime.Now.AddDays(3),
                    CreatedAt = DateTime.Now,
                    ProductId = "094830293849302938409569",
                },
                 new Auction()
                {
                    Name = "Auction 2",
                    Description = "Auction description",
                    IncludedSellers = new List<string>
                    {
                        "testseler1@vaz.az",
                        "testseler2@vaz.az",
                        "testseler3@vaz.az"
                    },
                    Status = (int)AuctionStatus.Active,
                    Quantity = 100,
                    StartedAt = DateTime.Now,
                    FinishedAt = DateTime.Now.AddDays(3),
                    CreatedAt = DateTime.Now,
                    ProductId = "0948302938g9302938409569",
                }
            };
        }

        private static IEnumerable<Bid> CustomizedBids()
        {
            return new List<Bid>
            {
                new Bid()
                {
                    AucationId= "0948302938g9302938409569",
                    CreatedAt =  DateTime.Now,
                    Price = 100,
                    ProductId = "0948302938g9302938409569",
                    SellerName = "turan"
                }
            };
        }
    }
}
