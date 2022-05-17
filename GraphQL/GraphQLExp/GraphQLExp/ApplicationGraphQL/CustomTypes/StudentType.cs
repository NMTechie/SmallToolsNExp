using GraphQL.Types;
using GraphQLExp.Models;
using GraphQLExp.Repository;

namespace GraphQLExp.ApplicationGraphQL.CustomTypes
{
    public class StudentType:ObjectGraphType<Student>
    {
        public StudentType(AddressRepository addressRepository,StudentRepository studentRepository)
        {
            Field(t => t.StudentId);
            Field(t => t.Name);
            Field(t => t.FirstName);
            Field(t => t.LastName);
            Field<AddressType>(
                "StudentAddress",
                "This field provides the address of a student",
                resolve: context => studentRepository.GetAddressOfAStudent(context.Source.StudentId));
            Field<ListGraphType<SubjectType>>(
                "AssignedSubjects",
                "This field provides the subjects list opted by a student",
                resolve: context => studentRepository.GetSubjctsOfAStudent(context.Source.StudentId));
            Field<IntGraphType>(
                "TotalScore",
                "This field provides score accumulated by a student",
                resolve: context => studentRepository.GetTotalScore(context.Source.StudentId));
        }
    }
}
