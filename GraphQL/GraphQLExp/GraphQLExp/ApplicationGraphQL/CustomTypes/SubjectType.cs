using GraphQL.Types;
using GraphQLExp.Models;

namespace GraphQLExp.ApplicationGraphQL.CustomTypes
{
    public class SubjectType : ObjectGraphType<Subject>
    {
        public SubjectType()
        {
            Field(t => t.SubjectId);
            Field(t => t.SubjectName);
            Field(t => t.SubjectWeightage);
            Field(t => t.AllotedTime);
        }
    }
}
