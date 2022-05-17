using GraphQLExp.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLExp.DataAccess
{
    public class InitialBootStrapper
    {
        public static void SeedInitialData(ApplicationDBContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            //dbContext.Database.Migrate();
            //
            List<Address> AddressesMasterCopy = new List<Address>();
            List<Teacher> TeacherMasterCopy = new List<Teacher>();
            List<Subject> SubjectMasterCopy = new List<Subject>();
            List<Student> StudentMasterCopy = new List<Student>();
            List<Score> ScoreMasterCopy = new List<Score>();

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
                    AddressId = AddressesMasterCopy[1].AddressID,
                    Address = AddressesMasterCopy[1],
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
            for (int i = 1; i <= 5; i++)
            {
                var subject = new Subject()
                {
                    SubjectId = i,
                    SubjectName = $"Subject {i.ToString()} ",
                    AllotedTime = i*10,
                    SubjectWeightage = i*5,
                    //AllotedTeachers = TeacherMasterCopy.Where(t => t.TeacherId <= i).ToList()
                };
                SubjectMasterCopy.Add(subject);
                dbContext.Add(subject);
                dbContext.Database.OpenConnection();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Subjects] ON");
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Subjects] OFF");
                dbContext.Database.CloseConnection();
            }
            //Insert Subject Teacher relationship
            int counter = 1;
            foreach (var subject in SubjectMasterCopy)
            {
                for (int k = 1; k <= subject.SubjectId; k++)
                {
                    var subjectTeacher = new SubjectTeacher()
                    {
                        Id = counter,
                        SubjectId = subject.SubjectId,
                        TeacherId = TeacherMasterCopy.Where(t => t.TeacherId == k).FirstOrDefault().TeacherId
                    };
                    dbContext.Add(subjectTeacher);
                    dbContext.Database.OpenConnection();
                    dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[SubjectTeacher] ON");
                    dbContext.SaveChanges();
                    dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[SubjectTeacher] OFF");
                    dbContext.Database.CloseConnection();
                    counter++;
                }
                
            }
            #endregion

            #region Student
            for (int i = 1; i <= 10; i++)
            {
                var student = new Student()
                {
                    StudentId = i,
                    LastName = $"StudentLastName {i.ToString()} ",
                    FirstName = $"StudentFirstName {i.ToString()} ",
                    AddressID = AddressesMasterCopy[0].AddressID,
                    Address = AddressesMasterCopy[0],
                    //OptedSubjects = SubjectMasterCopy.Where(t => t.SubjectId <= i).ToList()
                };
                StudentMasterCopy.Add(student);
                dbContext.Add(student);
                dbContext.Database.OpenConnection();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Students] ON");
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Students] OFF");
                dbContext.Database.CloseConnection();
            }
            //Insert Student Subject relationship
            counter = 1;
            foreach (var student in StudentMasterCopy)
            {
                for (int k = 1; k <= 5; k++)
                {                    
                    var studentSubject = new StudentSubject()
                    {
                        Id = counter,
                        StudentId = student.StudentId,
                        SubjectId = SubjectMasterCopy.Where(t => t.SubjectId == k).FirstOrDefault().SubjectId
                    };
                    dbContext.Add(studentSubject);
                    dbContext.Database.OpenConnection();
                    dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[StudentSubject] ON");
                    dbContext.SaveChanges();
                    dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[StudentSubject] OFF");
                    dbContext.Database.CloseConnection();
                    counter++;
                    if (k > student.StudentId)
                        break;
                }

                
            }
            #endregion

            #region
            for (int i = 1; i <= 10; i++)
            {
                var score = new Score()
                {
                    ScoreID = i,
                    MarksForStudent = StudentMasterCopy.Where(t => t.StudentId == i).First(),
                    MarksForSubject = (StudentMasterCopy.Where(t => t.StudentId == i).First()).OptedSubjects.Last().Subject,
                    MarksObtained = i * 15
                };
                ScoreMasterCopy.Add(score);
                dbContext.Add(score);
                dbContext.Database.OpenConnection();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Scores] ON");
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Scores] OFF");
                dbContext.Database.CloseConnection();
            }
            #endregion
        }
    }
}
