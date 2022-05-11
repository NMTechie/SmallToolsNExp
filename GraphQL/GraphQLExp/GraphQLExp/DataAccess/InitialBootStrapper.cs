using GraphQLExp.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLExp.DataAccess
{
    public class InitialBootStrapper
    {
        public static void SeedInitialData(ApplicationDBContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            List<Address> AddressesMasterCopy = new List<Address>();
            List<Teacher> TeacherMasterCopy = new List<Teacher>();

            #region Address
            var address1 = new Address() 
            {
                AddressID =  1,
                AddressLine1 = "Wondrland Complex",
                AddressLine2 = "P.K.GUHA ROAD",
                City = "DumDum",
                Country =  "India",
                Pincode = 700028 ,
                State = "WB"
            };
            AddressesMasterCopy.Add(address1);
            var address2 = new Address()
            {
                AddressID = 2,
                AddressLine1 = "Green Park Project",
                AddressLine2 = "Harimohan Dutta Road",
                City = "DumDum",
                Country = "India",
                Pincode = 700028,
                State = "WB"
            };
            AddressesMasterCopy.Add(address2);
            dbContext.Add(address1);
            dbContext.Add(address2);
            dbContext.Database.OpenConnection();
            dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Addresses] ON");
            dbContext.SaveChanges();
            dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Addresses] OFF");
            dbContext.Database.CloseConnection();
            #endregion

            #region Teacher
            for (int i = 1; i <= 10; i++)
            {
                var teacher = new Teacher() 
                {
                    TeacherId = i,
                    TeacherName = (i*10).ToString(),
                    Conatct = AddressesMasterCopy[1],
                };
                TeacherMasterCopy.Add(teacher);
                dbContext.Add(teacher);
                dbContext.Database.OpenConnection();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Teachers] ON");
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Teachers] OFF");
                dbContext.Database.CloseConnection();
            }
            
            #endregion

            #region Subject

            #endregion
        }
    }
}
