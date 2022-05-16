using GraphQL.Types;
using GraphQLExp.Models;

namespace GraphQLExp.ApplicationGraphQL.CustomTypes
{
    public class ScoreType : ObjectGraphType<Score>
    {
        public ScoreType()
        {
            Field(t => t.ScoreID);
            Field(t => t.MarksObtained);
        }
    }
}
