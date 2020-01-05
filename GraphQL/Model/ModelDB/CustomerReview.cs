using GraphQL.Model.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL1.Model.ModelDB
{
    public class CustomerReview
    {
        public string Id { get; set;}
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Title{ get; set; }
        public string Review { get; set; }
    }
}
