using GraphQL.Types;
using Orders.Models;
using Orders.Services.Interfaces;
using System;

namespace Orders.Schema
{
    public class OrdersMutation : ObjectGraphType<object>
    {
        public OrdersMutation(IOrderService orders)
        {
            Name = "Mutation";
            Field<OrderGraph>(
                "createOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OrderCreateInputGraph>> { Name = "order" }),
                resolve: context =>
                {
                    var orderInput = context.GetArgument<OrderCreateInput>("order");
                    var id = Guid.NewGuid().ToString();
                    var order = new Order(orderInput.Name, orderInput.Description, orderInput.Created, orderInput.CustomerId, id);
                    return orders.CreateAsync(order);
                }
            );

            FieldAsync<OrderGraph>(
                "startOrder",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "orderId" }),
                resolve: async context =>
                {
                    var orderId = context.GetArgument<string>("orderId");
                    return await context.TryAsyncResolve(
                        async c => await orders.StartAsync(orderId));
                }
            );
        }
    }
}
