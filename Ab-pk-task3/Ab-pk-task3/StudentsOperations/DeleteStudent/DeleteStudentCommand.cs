using Microsoft.EntityFrameworkCore;
using Ab_pk_task3.DBOperations;

namespace Ab_pk_task3.StudentsOperations.DeleteStudent
{
    public class DeleteStudentCommand
    {
        public int StudentID { get; set; }
        private readonly PatikaDbContext _dbContext;
        public DeleteStudentCommand(PatikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            // id üzerinden database sorgusu yapılır
            var student = _dbContext.Students.Where(x => x.StudentId == StudentID).SingleOrDefault();
            if (student is null)
                throw new InvalidOperationException("Silinecek Ögrenci Bulunamadı");
            // database işlemleri yapılır.
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();

        }
    }
}

