using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ContosoUniversity.Models;

namespace ContosoUniversity.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            //构建学生数据
            var students = new List<Student>
            {
                new Student {Name="A1" ,EnrollmentDate=DateTime.Parse("2001-1-9")},
                new Student {Name="B2" ,EnrollmentDate=DateTime.Parse("2002-2-8")},
                new Student {Name="C3" ,EnrollmentDate=DateTime.Parse("2003-3-7")},
                new Student {Name="D4" ,EnrollmentDate=DateTime.Parse("2004-4-6")},
                new Student {Name="F5" ,EnrollmentDate=DateTime.Parse("2005-5-5")},
                new Student {Name="G6" ,EnrollmentDate=DateTime.Parse("2006-6-4")},
                new Student {Name="H7" ,EnrollmentDate=DateTime.Parse("2007-7-3")},
                new Student {Name="I8" ,EnrollmentDate=DateTime.Parse("2008-8-2")},
                new Student {Name="J9" ,EnrollmentDate=DateTime.Parse("2009-9-1")},

            };
            //将学生数据加入实体集

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();
            //构建课程数据
            var courses = new List<Course>
            {
            new Course{CourseID=1050,Title="Chemistry",Credits=3,},
            new Course{CourseID=4022,Title="Microeconomics",Credits=3,},
            new Course{CourseID=4041,Title="Macroeconomics",Credits=3,},
            new Course{CourseID=1045,Title="Calculus",Credits=4,},
            new Course{CourseID=3141,Title="Trigonometry",Credits=4,},
            new Course{CourseID=2021,Title="Composition",Credits=3,},
            new Course{CourseID=2042,Title="Literature",Credits=4,}
            };
            //将课程数据加入实体集
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
            //构建注册数据
            var enrollments = new List<Enrollment>
            {
            new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{StudentID=3,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=1050,},
            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{StudentID=6,CourseID=1045},
            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            //将注册数据加入实体集
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}