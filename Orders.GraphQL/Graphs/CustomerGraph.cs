using GraphQL.Types;
using Orders.Models;

namespace Orders.Schema
{
    public class CustomerGraph : ObjectGraphType<Customer>
    {
        public CustomerGraph()
        {
            Field(c => c.Id);
            Field(c => c.Name);
        }
    }
}
