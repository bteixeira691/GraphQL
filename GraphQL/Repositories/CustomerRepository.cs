using GraphQL.Model.ModelDB;
using GraphQL.Mongo;
using GraphQL1.Model.ModelDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Repositories
{
    public class CustomerRepository
    {
        private readonly IMongoCollection<Customer> _customer;


        public CustomerRepository(IMongoDBConfig mongoDBConfig)
        {
            var client = new MongoClient(mongoDBConfig.ConnectionString);
            
            var database = client.GetDatabase(mongoDBConfig.Database);

            _customer = database.GetCollection<Customer>("customer");
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await _customer
                            .Find(_ => true)
                            .ToListAsync();
        }

        public async Task<Customer> GetCustomerId(string id)
        {
            return await _customer.Find(c=>c.Id==id).SingleOrDefaultAsync();
        }

        public async Task<Customer> AddCostumer(Customer customer)
        {

            await _customer.InsertOneAsync(customer);

            return customer;
        }
    }
}
