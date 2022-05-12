﻿using GraphQLExp.Models;
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
            for (int i = 1; i <= 5; i++)
            {
                var subject = new Subject()
                {
                    SubjectId = i,
                    SubjectName = $"Subject {i.ToString()} ",
                    AllotedTime = i*10,
                    SubjectWeightage = i*5,
                    AllotedTeachers = TeacherMasterCopy.Where(t => t.TeacherId <= i).ToList()
                };
                SubjectMasterCopy.Add(subject);
                dbContext.Add(subject);
                dbContext.Database.OpenConnection();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Subjects] ON");
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Subjects] OFF");
                dbContext.Database.CloseConnection();
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
                    ContactAddress = AddressesMasterCopy[0],
                    OptedSubjects = SubjectMasterCopy.Where(t => t.SubjectId <= i).ToList()
                };
                StudentMasterCopy.Add(student);
                dbContext.Add(student);
                dbContext.Database.OpenConnection();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Students] ON");
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Students] OFF");
                dbContext.Database.CloseConnection();
            }
            #endregion

            #region
            for (int i = 1; i <= 10; i++)
            {
                var score = new Score()
                {
                    ScoreID = i,
                    MarksForStudent = StudentMasterCopy.Where(t => t.StudentId == i).First(),
                    MarksForSubject = (StudentMasterCopy.Where(t => t.StudentId == i).First()).OptedSubjects.Last(),
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
