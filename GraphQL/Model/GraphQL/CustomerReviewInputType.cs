using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;

namespace GraphQL1.Model.GraphQL
{
    public class CustomerReviewInputType : InputObjectGraphType
    {
        public CustomerReviewInputType()
        {
            Name = "reviewInput";

            Field<NonNullGraphType<StringGraphType>>("title");
            Field<NonNullGraphType<StringGraphType>>("review");
            Field<NonNullGraphType<StringGraphType>>("customerId");

        }
    }
}
