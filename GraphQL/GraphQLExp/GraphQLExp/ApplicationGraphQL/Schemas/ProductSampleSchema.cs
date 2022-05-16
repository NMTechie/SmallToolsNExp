using GraphQL.Types;
using GraphQLExp.ApplicationGraphQL.CustomTypes;
using GraphQLExp.Models;

namespace GraphQLExp.ApplicationGraphQL.Schemas
{
    public class ProductSampleSchema : Schema
    {
        public ProductSampleSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetService<ProductSampleQuery>();
        }
    }

    public class ProductSampleQuery : ObjectGraphType
    {
        
        public ProductSampleQuery()
        {            
            Field<ListGraphType<ProductSampleType>>(
                "ProductSample",
                resolve: context => SampleProducts()
                );
        }

        private List<ProductSample> SampleProducts()
        {
            return new List<ProductSample> { new ProductSample() {Id=1,Name="Product Sample 1",Description="Sample 1" } };
        }
    }
}
