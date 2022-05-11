namespace GraphQLExp.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int SubjectWeightage { get; set; }
        public List<Teacher> AllotedTeachers { get; set; }
        public List<Student> OptedBy { get; set; }
        public int AllotedTime { get; set; }
    }
}
