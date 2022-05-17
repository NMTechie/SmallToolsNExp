namespace GraphQLExp.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pincode { get; set; }
        public string Country { get; set; }

        //Navigation property b/w Adress and Student
        public List<Student> Students { get; set; }

        //Navigation property b/w Adress and Teacher
        public List<Teacher> Teachers { get; set; }
    }
}
