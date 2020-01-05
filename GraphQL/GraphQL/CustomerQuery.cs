using GraphQL.Repositories;
using GraphQL.Types;
using GraphQL1.Model.GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL1.GraphQL
{
    public class CustomerQuery: ObjectGraphType
    {
        public CustomerQuery(CustomerRepository customerRepository)
        {
            Field<ListGraphType<CustomerType>>("customers", resolve: context => customerRepository.GetAllCustomer());

            Field<CustomerType>(
                "customer", 
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> 
                { Name= "id"}), 
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return customerRepository.GetCustomerId(id);
                }
           );

           
        }
    }
}
