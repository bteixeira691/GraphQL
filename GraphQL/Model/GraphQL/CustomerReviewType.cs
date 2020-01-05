using GraphQL.Types;
using GraphQL1.Model.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL1.Model.GraphQL
{
    public class CustomerReviewType : ObjectGraphType<CustomerReview>
    {
        public CustomerReviewType()
        {
            Field(t=>t.Id);
            Field(t => t.Title);
            Field(t => t.Review);
        }
    }
}
