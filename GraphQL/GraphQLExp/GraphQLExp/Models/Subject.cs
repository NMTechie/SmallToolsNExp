namespace GraphQLExp.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int SubjectWeightage { get; set; }        
        public int AllotedTime { get; set; }

        // Navigation property b/w Subject and Student
        public List<StudentSubject> OptedBy { get; set; }

        // Navigation property b/w Subject and Teacher
        public List<SubjectTeacher> AllotedTeachers { get; set; }
    }
}
