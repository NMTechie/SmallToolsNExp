using GraphQL.Types;
using GraphQLExp.Models;

namespace GraphQLExp.ApplicationGraphQL.CustomTypes
{
    public class ProductSampleType : ObjectGraphType<ProductSample>
    {
        public ProductSampleType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.Description);
        }
    }
}
