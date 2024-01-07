using Microsoft.EntityFrameworkCore;
using Ab_pk_task3.DBOperations;
using Ab_pk_task3.Models;

namespace Ab_pk_task3.StudentsOperations.UpdateStudent
{
    public class UpdateStudentCommand
    {
        public int StudentID { get; set; }
        public UpdateStudentModel Model { get; set; }
        private readonly PatikaDbContext _dbContext;
        public UpdateStudentCommand(PatikaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var student = _dbContext.Students.Where(x => x.StudentId == StudentID).SingleOrDefault();

            if (student is null)
                throw new InvalidOperationException("Gücellenecek Ögrenci Bulunamadı");

            student.Name = Model.Name != default ? Model.Name : student.Name;
            student.Surname = Model.Surname != default ? Model.Surname : student.Surname;
            student.BookGenreId = Model.BookGenreId != default ? Model.BookGenreId : student.BookGenreId;
            student.ClassId = Model.ClassId != default ? Model.ClassId : student.ClassId;
            student.TestDate = Model.TestDate != default ? Model.TestDate : student.TestDate;
 
            _dbContext.Students.Update(student);
            _dbContext.SaveChanges();

        }
    }
    public class UpdateStudentModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ClassId { get; set; }
        public int BookGenreId { get; set; }
        public DateTime TestDate { get; set; }
    }
}
