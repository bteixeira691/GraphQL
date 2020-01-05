using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Model.ModelDB;
using GraphQL.Repositories;
using GraphQL.Types;
using GraphQL1.Model.GraphQL;
using GraphQL1.Model.ModelDB;
using GraphQL1.Repositories;

namespace GraphQL1.GraphQL
{
    public class CustomerMutation : ObjectGraphType
    {
        public CustomerMutation(CustomerRepository customerRepository, CustomerReviewRepository customerReviewRepository)
        {
            FieldAsync<CustomerType>("createCustomer",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CustomerInputType>> { Name = "customer" }),
                resolve: async context =>
                {
                    var customer = context.GetArgument<Customer>("customer");
                    return await context.TryAsyncResolve(
                        async c => await customerRepository.AddCostumer(customer));
                });

            FieldAsync<CustomerReviewType>("createReviewCustomer",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CustomerReviewInputType>> { Name = "review" }),
               resolve: async context =>
               {
                   var customer = context.GetArgument<CustomerReview>("customerReview");
                   return await context.TryAsyncResolve(
                       async c => await customerReviewRepository.AddReview(customer));
               });
        }
    }
}
