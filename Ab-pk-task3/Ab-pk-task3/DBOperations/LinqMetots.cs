using Ab_pk_task3.Models;

namespace Ab_pk_task3.DBOperations;

public class LinqMetots
{
    private readonly PatikaDbContext dbContext;
    public LinqMetots(PatikaDbContext dbContext) 
    {
        this.dbContext = dbContext; 
    }

    public  void Find()
    {
        // Find()
        var student = dbContext.Students.Where(x=>x.StudentId==1).FirstOrDefault();
        student = dbContext.Students.Find(1); // id ye göre getirir
        //FirstOrDefault
        student = dbContext.Students.Where(x => x.Surname == "y.").FirstOrDefault();
        student = dbContext.Students.FirstOrDefault(x=>x.Surname=="y."); // where kullanılmadan firtordefault kullanılabilir

        // SingleOrDefault ve ya single sonucun bir deger oldugu yerlerde kullanılır
        student = dbContext.Students.SingleOrDefault(x=>x.Surname=="y.");

        // tolist list olarak veri gtirir
        var students = dbContext.Students.Where(x => x.ClassId == 2).ToList();

        // Orderby istenlen degerleri sıralamada kullanılır
        students = dbContext.Students.OrderBy(x => x.ClassId).ToList();

        // Orderby istenlen degerleri ters sıralamada kullanılır
        students = dbContext.Students.OrderByDescending(x => x.ClassId).ToList();

        // burada anonymousObject select içerisinde yazılan sınıfa göre oluşturulur
        var anonymousObject = dbContext.Students.Where(x => x.ClassId == 2)
            .Select(x => new
            {
                Id = x.StudentId,
                FullName = x.Name + " " + x.Surname
            });
    }
}

