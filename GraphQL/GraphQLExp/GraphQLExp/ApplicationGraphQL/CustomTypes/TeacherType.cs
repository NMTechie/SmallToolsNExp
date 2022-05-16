using GraphQL.Types;
using GraphQLExp.Models;

namespace GraphQLExp.ApplicationGraphQL.CustomTypes
{
    public class TeacherType : ObjectGraphType<Teacher>
    {
        public TeacherType()
        {
            Field(t => t.TeacherId);
            Field(t => t.TeacherName);
        }
    }
}
