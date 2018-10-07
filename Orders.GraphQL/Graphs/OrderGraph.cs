using GraphQL.Types;
using Orders.Models;
using Orders.Services.Interfaces;

namespace Orders.Schema
{
    public class OrderGraph : ObjectGraphType<Order>
    {
        public OrderGraph(ICustomerService customers)
        {
            Field(o => o.Id);
            Field(o => o.Name);
            Field(o => o.Description);
            Field<CustomerGraph>("customer",
                resolve: context => customers.GetCustomerByIdAsync(context.Source.CustomerId));
            Field(o => o.Created);
            Field<OrderStatusesEnum>("status",
                resolve: context => context.Source.Status);
        }
    }
}
