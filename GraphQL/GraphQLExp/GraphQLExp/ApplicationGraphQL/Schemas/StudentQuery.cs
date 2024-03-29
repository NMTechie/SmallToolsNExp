﻿using GraphQL.Types;
using GraphQLExp.ApplicationGraphQL.CustomTypes;
using GraphQLExp.Repository;

namespace GraphQLExp.ApplicationGraphQL.Schemas
{
    public class StudentQuery : ObjectGraphType
    {
        public readonly StudentRepository _studentRepository;
        public StudentQuery(StudentRepository studentRepo)
        {
            _studentRepository = studentRepo;
            Field<ListGraphType<StudentType>>(
                "Students",
                resolve: context => _studentRepository.GetAll()
                );
            Field<StudentType>(
                "Student",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>>() { Name = "studentId" }),
                resolve: context => 
                {
                    var id = (int)context.Arguments["studentId"].Value;
                    return _studentRepository.GetStudentDetails(id); 
                }
                );
        }
    }
}
