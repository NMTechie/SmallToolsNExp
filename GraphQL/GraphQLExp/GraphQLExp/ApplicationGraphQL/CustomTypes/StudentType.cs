using GraphQL.Types;
using GraphQLExp.Models;
using GraphQLExp.Repository;

namespace GraphQLExp.ApplicationGraphQL.CustomTypes
{
    public class StudentType:ObjectGraphType<Student>
    {
        public StudentType(AddressRepository addressRepository,SubjectRepository subjectRepository)
        {
            Field(t => t.StudentId);
            Field(t => t.Name);
            Field(t => t.FirstName);
            Field(t => t.LastName);
            Field<AddressType>(
                "StudentAddress",
                "This field provides the address of a student",
                resolve: context => addressRepository.GetAddressOfAStudent(context.Source.StudentId));
            Field<ListGraphType<SubjectType>>(
                "StudentSubjects",
                "This field provides the subjects list opted by a student",
                resolve: context => subjectRepository.GetSubjctsOfAStudent(context.Source.StudentId));
        }
    }
}
