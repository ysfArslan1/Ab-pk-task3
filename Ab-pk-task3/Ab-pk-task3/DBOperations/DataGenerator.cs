using Microsoft.EntityFrameworkCore;
using Ab_pk_task3.Models;

namespace Ab_pk_task3.DBOperations;

public class DataGenerator
{
    //inmemory de data üretmek içinkullanılıyor // program.cs de çalıştırılıyor
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var content = new PatikaDbContext(serviceProvider.GetRequiredService<DbContextOptions<PatikaDbContext>>())) 
        {
           
            content.SaveChanges();

            if (content.Students.Any())
            {
                return;
            }

            content.Students.AddRange(
                new Student
                {
                    Name="ayse",
                    Surname="y.",
                    ClassId=1,
                    BookGenreId=1,
                    TestDate=DateTime.Now,
                },
                new Student
                {
                    Name = "ali",
                    Surname = "d.",
                    ClassId = 1,
                    BookGenreId = 1,
                    TestDate = DateTime.Now,
                },
                new Student
                {
                    Name = "akif",
                    Surname = "f.",
                    ClassId = 2,
                    BookGenreId = 2,
                    TestDate = DateTime.Now,
                },
                new Student
                {
                    Name = "cuma",
                    Surname = "g.",
                    ClassId = 2,
                    BookGenreId = 3,
                    TestDate = DateTime.Now,
                }
            );

            content.SaveChanges();
        }
    }
}

