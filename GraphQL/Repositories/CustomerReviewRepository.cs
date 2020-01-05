using GraphQL.Mongo;
using GraphQL1.Model.ModelDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL1.Repositories
{
    public class CustomerReviewRepository
    {
        private readonly IMongoCollection<CustomerReview> _customerReview;


        public CustomerReviewRepository(IMongoDBConfig mongoDBConfig)
        {
            var client = new MongoClient(mongoDBConfig.ConnectionString);
            var database = client.GetDatabase(mongoDBConfig.Database);

            _customerReview = database.GetCollection<CustomerReview>("customerReview");
        }

        public async Task<IEnumerable<CustomerReview>> GetAllCustomerReview()
        {
            return await _customerReview
                            .Find(_ => true)
                            .ToListAsync();
        }

        public async Task<CustomerReview> AddReview(CustomerReview review)
        {
            await _customerReview.InsertOneAsync(review);
            return review;
        }

        public async Task<ILookup<string, CustomerReview>> GetReviewsByCustomerId(IEnumerable<string> customerIds)
        {
            var reviews = await _customerReview.Find(pr => customerIds.Contains(pr.CustomerId)).ToListAsync();
            return reviews.ToLookup(r => r.CustomerId);
        }
    }
}
