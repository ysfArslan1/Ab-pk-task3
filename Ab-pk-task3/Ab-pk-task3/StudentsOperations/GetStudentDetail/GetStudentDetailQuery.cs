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
            // ögrenci verisi databaseden alınır.
            var student = _dbContext.Students.Where(x => x.StudentId == StudentID).SingleOrDefault();
            if (student is null)
                throw new InvalidOperationException("Ögrenci Bulunamadı");
            // mapping ile Student sınıfından StudentDetailViewModel verisi oluşturulur
            StudentDetailViewModel studentDetail = _mapper.Map<StudentDetailViewModel>(student);
            
            return studentDetail;
        }
    }
    // Student sınıfı geri döndürmek için yazılan sınıf
    public class StudentDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Class { get; set; }
        public string BookGenre { get; set; }
        public string TestDate { get; set; }
    }

}
