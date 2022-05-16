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
    }
}
