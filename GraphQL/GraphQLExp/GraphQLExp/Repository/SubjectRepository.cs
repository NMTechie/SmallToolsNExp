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
            return new List<Subject>();
        }

        internal List<Teacher> GetAssignedTeacher(int subjectId)
        {
            var assignedTeacherMapping = _dbContext.SubjectTeacher.Where(x => x.SubjectId == subjectId).ToList(); ;
            List<Teacher> assignedTeacher = new List<Teacher>();
            foreach (var teacher in assignedTeacherMapping)
            {
                assignedTeacher.Add(_dbContext.Teachers.Where(t => t.TeacherId == teacher.TeacherId).First());
            }
            return assignedTeacher;
        }
    }
}
