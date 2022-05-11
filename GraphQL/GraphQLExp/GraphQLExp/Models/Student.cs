namespace GraphQLExp.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Name 
        {
            get 
            {
                return FirstName + " " + LastName;
            }
        }
        public List<Subject> OptedSubjects { get; set; }
        public Address ContactAddress { get; set; }
    }
}
