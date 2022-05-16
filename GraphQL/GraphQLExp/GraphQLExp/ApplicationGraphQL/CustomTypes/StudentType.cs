using GraphQL.Types;
using GraphQLExp.Models;

namespace GraphQLExp.ApplicationGraphQL.CustomTypes
{
    public class StudentType:ObjectGraphType<Student>
    {
        public StudentType()
        {
            Field(t => t.StudentId);
            Field(t => t.Name);
            Field(t => t.ContactAddress);
        }
    }
    public class AddressType : ObjectGraphType<Address>
    {
        public AddressType()
        {
            Field(t => t.AddressID);
            Field(t => t.AddressLine1);
            Field(t => t.AddressLine2);
        }
    }
    public class SubjectType : ObjectGraphType<Subject>
    {
        public SubjectType()
        {
            Field(t => t.SubjectId);
            Field(t => t.SubjectName);
            Field(t => t.SubjectWeightage);
        }
    }
    public class TeacherType : ObjectGraphType<Teacher>
    {
        public TeacherType()
        {
            Field(t => t.TeacherId);
            Field(t => t.TeacherName);
        }
    }
    public class ScoreType : ObjectGraphType<Score>
    {
        public ScoreType()
        {
            Field(t => t.ScoreID);;
        }
    }
}
