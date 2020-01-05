using GraphQL.DataLoader;
using GraphQL.Model.ModelDB;
using GraphQL.Repositories;
using GraphQL.Types;
using GraphQL1.Model.ModelDB;
using GraphQL1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL1.Model.GraphQL
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType(CustomerReviewRepository customerRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id);
            Field(t => t.Name).Description("The name of the Customer");
            Field(t => t.Description);
            Field(t => t.Photo).Description("The file name of the photo");
        
            Field<ListGraphType<CustomerReviewType>>("reviews",
              resolve: context =>
              {
                  var loader =
                      dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<string, CustomerReview>(
                          "GetReviewsByCustomerId", customerRepository.GetReviewsByCustomerId);
                  return loader.LoadAsync(context.Source.Id);
              });

        }
    }
}
