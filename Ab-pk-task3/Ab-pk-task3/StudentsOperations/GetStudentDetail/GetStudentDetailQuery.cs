using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ab_pk_task3.BankAccountOperations.GetBA;
using Ab_pk_task3.Common;
using Ab_pk_task3.DBOperations;

namespace Ab_pk_task3.StudentsOperations.GetStudentDetail
{
    public class GetStudentDetailQuery
    {

        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;
        public int StudentID { get; set; }
        public GetStudentDetailQuery(PatikaDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public StudentDetailViewModel Handle()
        {
            var student = _dbContext.Students.Where(x => x.StudentId == StudentID).SingleOrDefault();
           
            if (student is null)
                throw new InvalidOperationException("Ögrenci Bulunamadı");

            StudentDetailViewModel studentDetail = _mapper.Map<StudentDetailViewModel>(student);
            // auto mapper kullanıldı
            //studentDetail.Name = student.Name;
            //studentDetail.Surname = student.Surname;
            //studentDetail.Class = ((ClassEnum)student.ClassId).ToString();
            //studentDetail.BookGenre = ((BookGenreEnum)student.BookGenreId).ToString();
            //studentDetail.TestDate = student.TestDate.Date.ToString("dd/MM/yyyy");
            
            return studentDetail;
        }
    }
    public class StudentDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Class { get; set; }
        public string BookGenre { get; set; }
        public string TestDate { get; set; }
    }

}
