namespace GraphQLExp.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        
        //Navigation property b/w Teacher and Address
        public int AddressId { get; set; }
        public Address Address { get; set; }

        //Navigation property b/w Teacher and Subject
        public List<SubjectTeacher> SubjectsAlloted { get; set; }
    }
}
