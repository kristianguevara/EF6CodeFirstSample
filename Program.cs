using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new StudentContext())
            {
                var student = new Student() { Name = "est Name" };
                var mathSubj = new Subject() { Name = "Mathemetics" };
                var scienceSubj = new Subject() { Name = "Data structures" };


                db.Students.Add(student);
                db.SaveChanges();
            }
        }

    }

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public virtual List<Subject> Subjects { get; set; }

        public Student()
        {
            this.Subjects = new List<Subject>();
        }
    }

    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public virtual Student Students { get; set;}
    }

    

    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
