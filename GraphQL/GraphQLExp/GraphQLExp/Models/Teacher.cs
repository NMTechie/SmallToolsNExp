namespace GraphQLExp.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public Address Conatct { get; set; }
        public List<Subject> SubjectsAlloted { get; set; }
    }
}
