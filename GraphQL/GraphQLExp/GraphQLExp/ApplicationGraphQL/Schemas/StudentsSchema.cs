using GraphQL;
using GraphQL.Types;

namespace GraphQLExp.ApplicationGraphQL.Schemas
{
    public class StudentsSchema : Schema
    {
        public StudentsSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetService<StudentQuery>();
        }
    }
}
