namespace GraphQLExp.Models
{
    public class Score
    {
        public int ScoreID { get; set; }
        public Student MarksForStudent { get; set; }
        public Subject MarksForSubject { get; set; }
        public int MarksObtained { get; set; }
    }
}
