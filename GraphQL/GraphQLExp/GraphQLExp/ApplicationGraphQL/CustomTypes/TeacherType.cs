using GraphQL.Types;
using GraphQLExp.Models;
using GraphQLExp.Repository;

namespace GraphQLExp.ApplicationGraphQL.CustomTypes
{
    public class TeacherType : ObjectGraphType<Teacher>
    {
        public TeacherType(TeacherRepository teacherRepository)
        {
            Field(t => t.TeacherId);
            Field(t => t.TeacherName);
            Field<AddressType>(
                "TeacherAddress",
                "This field provides the address of a Teacher",
                resolve: context => teacherRepository.GetAddressOfATeacher(context.Source.TeacherId));
        }
    }
}
