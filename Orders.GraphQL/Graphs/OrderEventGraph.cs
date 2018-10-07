using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using Orders.Models;

namespace Orders.Schema
{
    public class OrderEventGraph : ObjectGraphType<OrderEvent>
    {
        public OrderEventGraph()
        {
            Field(e => e.Id);
            Field(e => e.Name);
            Field(e => e.OrderId);
            Field<OrderStatusesEnum>("status",
                resolve: context => context.Source.Status);
            Field(e => e.Timestamp);
        }
    }
}
