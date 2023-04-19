using cv11.EFCore;
using Microsoft.EntityFrameworkCore;

using (var context = new LibraryContext())
{
    context.Database.Migrate();
    LibraryContext.FullData(context);

    var counting = from p in context.StudentSubjects
                   group p by p.AbbreviationId into g
                   orderby g.Count() descending
                   select new { StudentId = g.Key, Pocet = g.Count()};
    foreach(var student in counting)
    {
        Console.WriteLine("({0}): {1}", student.StudentId,student.Pocet);
    }
}


static IEnumerable<Student> StudentSubject(LibraryContext context, string AbbreviationId)
{
    return from sp in context.StudentSubjects
           join s in context.Students on sp.StudentId equals s.StudentId
           where sp.AbbreviationId == AbbreviationId
           select s;
}