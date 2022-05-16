using GraphQLExp.DataAccess;
using GraphQLExp.Models;

namespace GraphQLExp.Repository
{
    public class AddressRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public AddressRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Address GetAddressOfAStudent(int studentId)
        {
            return _dbContext.Students.Where(x => x.StudentId == studentId).FirstOrDefault().ContactAddress;
        }
    }
}
