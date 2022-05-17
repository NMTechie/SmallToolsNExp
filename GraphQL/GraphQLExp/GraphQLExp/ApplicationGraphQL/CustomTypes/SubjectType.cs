using GraphQL.Types;
using GraphQLExp.Models;
using GraphQLExp.Repository;

namespace GraphQLExp.ApplicationGraphQL.CustomTypes
{
    public class SubjectType : ObjectGraphType<Subject>
    {
        public SubjectType(SubjectRepository subjectRepository)
        {
            Field(t => t.SubjectId);
            Field(t => t.SubjectName);
            Field(t => t.SubjectWeightage);
            Field(t => t.AllotedTime);
            Field<ListGraphType<TeacherType>>(
                "AllotedTeacher",
                "This field provides the teacher assigned for the subject",
                resolve: context => subjectRepository.GetAssignedTeacher(context.Source.SubjectId));
        }
    }
}
