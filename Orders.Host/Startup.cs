﻿using GraphQL;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Transports.WebSockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Orders.Schema;
using Orders.Services;
using Orders.Services.Interfaces;

namespace Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<OrderGraph>();
            services.AddSingleton<CustomerGraph>();
            services.AddSingleton<OrderStatusesEnum>();
            services.AddSingleton<OrdersQuery>();
            services.AddSingleton<OrdersSchema>();
            services.AddSingleton<OrderCreateInputGraph>();
            services.AddSingleton<OrdersMutation>();
            services.AddSingleton<OrdersSubscription>();
            services.AddSingleton<OrderEventGraph>();
            services.AddSingleton<IOrderEventService, OrderEventService>();
            services.AddSingleton<IDependencyResolver>(
                c => new FuncDependencyResolver(type => c.GetRequiredService(type)));
            services.AddGraphQLHttp();
            services.AddGraphQLWebSocket<OrdersSchema>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseWebSockets();
            app.UseGraphQLWebSocket<OrdersSchema>(new GraphQLWebSocketsOptions());
            app.UseGraphQLHttp<OrdersSchema>(new GraphQLHttpOptions());
        }
    }
}
