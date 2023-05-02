using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv11.EFCore
{
    internal class LibraryContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Student\source\repos\cv11\cv11\Database1.mdf;Connect Timeout=30");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>().HasKey(e => new { e.AbbreviationId });
            modelBuilder.Entity<Student>().HasKey(e => new { e.StudentId });
            modelBuilder.Entity<Grades>().HasKey(e => new { e.StudentId ,e.NameofSubjectId });
            modelBuilder.Entity<StudentSubject>().HasKey(e=>new {e.StudentId, e.AbbreviationId });
        }
        public static void FullData(LibraryContext context)
        {
            
            if (!context.Students.Any(s => s.StudentId == 1))
            {
                context.Students.Add(new Student() { Name = "Stano", Surname = "Jano", DateOfBirth = new DateTime(2001, 8, 4) });
            }
            if (!context.Students.Any(s => s.StudentId == 2))
            {
                context.Students.Add(new Student() {  Name = "Oliver", Surname = "Kubo", DateOfBirth = new DateTime(2002, 8, 4) });
            }
            if (!context.Students.Any(s => s.StudentId == 3))
            {
                context.Students.Add(new Student() {  Name = "Lukas", Surname = "Jano", DateOfBirth = new DateTime(2003, 8, 4) });
            }
            if (!context.Subjects.Any(a => a.AbbreviationId == "ANA"))
            {
                context.Subjects.Add(new Subject() { AbbreviationId = "ANA", Name = "Analogova Technika" });
            }
            if (!context.Subjects.Any(a => a.AbbreviationId == "MVA"))
            {
                context.Subjects.Add(new Subject() { AbbreviationId = "MVA", Name = "Meranie v elektro" });
            }
            if (!context.Subjects.Any(a => a.AbbreviationId == "OOP"))
            {
                context.Subjects.Add(new Subject() { AbbreviationId = "OOP", Name = "Objektove programko" });
            }
            if (!context.Grades.Any(( g => g.StudentId == 1 && g.NameofSubjectId == "ANA")))
            {
                context.Grades.Add(new Grades() { StudentId = 1, NameofSubjectId = "ANA", DateOfGrade = new DateTime(2023, 2, 1), Grade = 1 });
            }
            if (!context.Grades.Any((g => g.StudentId == 2 && g.NameofSubjectId == "MVA")))
            {
                context.Grades.Add(new Grades() { StudentId = 2, NameofSubjectId = "MVA", DateOfGrade = new DateTime(2022, 2, 1), Grade = 1 });
            }
            if (!context.Grades.Any((g => g.StudentId == 3 && g.NameofSubjectId == "OOP")))
            {
                context.Grades.Add(new Grades() { StudentId = 3, NameofSubjectId = "OOP", DateOfGrade = new DateTime(2021, 2, 1), Grade = 1 });
            }
            if(!context.StudentSubjects.Any(s=>s.StudentId==1 && s.AbbreviationId== "ANA"))
            {
                context.StudentSubjects.Add(new StudentSubject() { StudentId = 1, AbbreviationId = "ANA" });
            }
            if (!context.StudentSubjects.Any(s => s.StudentId == 2 && s.AbbreviationId == "MVA"))
            {
                context.StudentSubjects.Add(new StudentSubject() { StudentId = 2, AbbreviationId = "MVA" });
            }
            if (!context.StudentSubjects.Any(s => s.StudentId == 3 && s.AbbreviationId == "OOP"))
            {
                context.StudentSubjects.Add(new StudentSubject() { StudentId = 3, AbbreviationId = "OOP" });
            }
            context.SaveChanges();
        }
    }
    

}
