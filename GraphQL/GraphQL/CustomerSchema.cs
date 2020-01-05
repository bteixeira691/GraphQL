using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL1.GraphQL
{
    public class CustomerSchema : Schema
    {
        public CustomerSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<CustomerQuery>();
            Mutation = dependencyResolver.Resolve<CustomerMutation>();
        }
    }
}
