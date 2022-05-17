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
        //Navigation property b/w Student and Address
        public int AddressID { get; set; } // If Student may have address then it will be int?
        public Address Address { get; set; }
        // Navigation property b/w Student and Subject
        public List<StudentSubject> OptedSubjects { get; set; }


    }
}
