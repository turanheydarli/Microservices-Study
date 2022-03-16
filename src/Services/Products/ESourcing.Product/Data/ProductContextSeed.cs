using ESourcing.Products.Entities;
using MongoDB.Driver;

namespace ESourcing.Products.Data
{
    public static class ProductContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool isExist = productCollection.Find(p => true).Any();

            if (!isExist)
            {
                productCollection.InsertMany(GetConfigureProducts());
            }
        }

        private static IEnumerable<Product> GetConfigureProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "Iphone X",
                    Summary = "Lorem impusum dolor sit. Slom new all main network.",
                    Category = "Phones",
                    Description = "Lorem impusum dolor sit. Slom new all main network.",
                    ImagePath = "image1.jpg",
                    Price = 100
                },
                new Product
                {
                    Name = "Iphone 13",
                    Summary = "Lorem impusum dolor sit. Slom new all main network.",
                    Category = "Phones",
                    Description = "Lorem impusum dolor sit. Slom new all main network.",
                    ImagePath = "image2.jpg",
                    Price = 100
                },
                new Product
                {
                    Name = "Iphone 11",
                    Summary = "Lorem impusum dolor sit. Slom new all main network.",
                    Category = "Phones",
                    Description = "Lorem impusum dolor sit. Slom new all main network.",
                    ImagePath = "image3.jpg",
                    Price = 100
                }
            };
        }
    }
}
