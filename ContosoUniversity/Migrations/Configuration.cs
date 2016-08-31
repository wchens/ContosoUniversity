namespace ContosoUniversity.Migrations
{
    using ContosoUniversity.Models;
    using ContosoUniversity.DAL;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContosoUniversity.DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ContosoUniversity.DAL.SchoolContext";
        }

        protected override void Seed(ContosoUniversity.DAL.SchoolContext context)
        {
            var students = new List<Student>
            {
                new Student { FirstMidName = "Carson", LastName = "Alexander",
                            EnrollmentDate = DateTime.Parse("2010-09-01") },
                new Student { FirstMidName = "Meredith", LastName = "Alonso",
                            EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Arturo", LastName = "Anand",
                            EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Gytis", LastName = "Barzdukas",
                            EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Yan", LastName = "Li",
                            EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Peggy", LastName = "Justice",
                            EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Student { FirstMidName = "Laura", LastName = "Norman",
                            EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Nino", LastName = "Olivetto",
                            EnrollmentDate = DateTime.Parse("2005-09-01") }
            };
            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var instructors = new List<Instructor>
            {
                new Instructor 
                {
                    FirstMidName = "Kim", 
                    LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11") 
                },
                new Instructor 
                {   
                    FirstMidName = "Fadi", 
                    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06") 
                },
                new Instructor 
                { 
                    FirstMidName = "Roger", 
                    LastName = "Harui",
                    HireDate = DateTime.Parse("1998-07-01") 
                },
                new Instructor 
                { 
                    FirstMidName = "Candace", 
                    LastName = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15") 
                },
                new Instructor 
                { 
                    FirstMidName = "Roger", 
                    LastName = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12") 
                }
            };
            instructors.ForEach(s => context.Instructors.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department 
                { 
                    Name = "English", 
                    Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID = instructors.Single( i => i.LastName == "Abercrombie").ID 
                },
                new Department 
                { 
                    Name = "Mathematics", 
                    Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID = instructors.Single( i => i.LastName == "Fakhouri").ID 
                },
                new Department 
                { 
                    Name = "Engineering", 
                    Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID = instructors.Single( i => i.LastName == "Harui").ID 
                },
                new Department 
                { 
                    Name = "Economics", 
                    Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID = instructors.Single( i => i.LastName == "Kapoor").ID 
                }
            };
            departments.ForEach(s => context.Departments.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course 
                {
                    CourseID = 1050, 
                    Title = "Chemistry", 
                    Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID,
                    Instructors = new List<Instructor>()
                },
                new Course 
                {
                    CourseID = 4022, 
                    Title = "Microeconomics", 
                    Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID,
                    Instructors = new List<Instructor>()
                },
                new Course 
                {
                    CourseID = 4041, 
                    Title = "Macroeconomics", 
                    Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID,
                    Instructors = new List<Instructor>()
                },
                new Course 
                {
                    CourseID = 1045, 
                    Title = "Calculus", 
                    Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID,
                    Instructors = new List<Instructor>()
                },
                new Course 
                {
                    CourseID = 3141, 
                    Title = "Trigonometry", 
                    Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID,
                    Instructors = new List<Instructor>()
                },
                new Course 
                {
                    CourseID = 2021, 
                    Title = "Composition", 
                    Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "English").DepartmentID,
                    Instructors = new List<Instructor>()
                },
                new Course 
                {
                    CourseID = 2042, 
                    Title = "Literature", 
                    Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "English").DepartmentID,
                    Instructors = new List<Instructor>()
                }
            };
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseID, s));
            context.SaveChanges();


        }
    }
}
