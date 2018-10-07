using GraphQL.Types;
using Orders.Services.Interfaces;

namespace Orders.Schema
{
    public class OrdersQuery : ObjectGraphType<object>
    {
        public OrdersQuery(IOrderService orders)
        {
            Name = "Query";
            Field<ListGraphType<OrderGraph>>(
                "orders",
                resolve: context => orders.GetOrdersAsync()
            );
        }
    }
}
