using GraphQLExp.DataAccess;
using GraphQLExp.Models;

namespace GraphQLExp.Repository
{
    public class SubjectRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public SubjectRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Subject> GetSubjctsOfAStudent(int studentId)
        {
            return _dbContext.Students.Where(x => x.StudentId == studentId).FirstOrDefault().OptedSubjects;
        }
    }
}
