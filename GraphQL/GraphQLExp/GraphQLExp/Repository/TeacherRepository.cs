using GraphQLExp.DataAccess;
using GraphQLExp.Models;

namespace GraphQLExp.Repository
{
    public class TeacherRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public TeacherRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        internal Address GetAddressOfATeacher(int teacherId)
        {
            var addressid = _dbContext.Teachers.Where(x => x.TeacherId == teacherId).FirstOrDefault().AddressId;
            return _dbContext.Addresses.Where(x => x.AddressID == addressid).FirstOrDefault();
        }
    }
}
