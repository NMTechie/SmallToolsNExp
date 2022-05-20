using GraphQL.Types;
using GraphQLExp.DataAccess;
using GraphQLExp.Models;

namespace GraphQLExp.Repository
{
    public class StudentRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public StudentRepository(ApplicationDBContext dbContext)
        {
               _dbContext = dbContext;
        }

        public List<Student> GetAll()
        {
            return _dbContext.Students.ToList();
        }
        public Student GetStudentDetails(int id)
        {
            return _dbContext.Students.Where(x=>x.StudentId == id).FirstOrDefault();
        }
        internal Address GetAddressOfAStudent(int studentId)
        {
            var addressid = _dbContext.Students.Where(x => x.StudentId == studentId).FirstOrDefault().AddressID;
            return _dbContext.Addresses.Where(x=>x.AddressID==addressid).FirstOrDefault();
        }

        internal List<Subject> GetSubjctsOfAStudent(int studentId)
        {
            
            var optedSubjectMapping = _dbContext.StudentSubject.Where(x => x.StudentId == studentId).ToList();
            List<Subject> subjcts = new List<Subject>();
            foreach (var optedSubject in optedSubjectMapping)
            { 
                subjcts.Add(_dbContext.Subjects.Where(s=>s.SubjectId==optedSubject.SubjectId).First());
            }
            return subjcts;
        }
        internal int GetTotalScore(int studentId)
        {
            var optedSubjectMapping = _dbContext.StudentSubject.Where(x => x.StudentId == studentId).ToList();
            int totalScore = 0;
            foreach (var item in optedSubjectMapping)
            {
                var score = _dbContext.Scores.Where(x => x.MarksForStudent.StudentId == studentId && x.MarksForSubject.SubjectId == item.SubjectId).FirstOrDefault();
                if(score!=null)
                    totalScore = totalScore + score.MarksObtained;
            }
            return totalScore;
        }
    }
}
