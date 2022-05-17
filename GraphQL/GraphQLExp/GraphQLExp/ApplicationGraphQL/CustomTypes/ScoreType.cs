using GraphQL.Types;
using GraphQLExp.Models;

namespace GraphQLExp.ApplicationGraphQL.CustomTypes
{
    public class ScoreType : ObjectGraphType
    {
        public ScoreType()
        {
            Field<IntGraphType>("TotalScore");
        }
    }
}
