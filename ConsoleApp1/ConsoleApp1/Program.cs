using ConsoleApp1.Context;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SchoolContext())
            {
                var stud = new Student() { StudentName = "Tien" };

                ctx.Students.Add(stud);
                ctx.SaveChanges();
            }
        }
    }
}