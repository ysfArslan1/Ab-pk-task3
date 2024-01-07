
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ab_pk_task3.Common;
using Ab_pk_task3.DBOperations;
using Ab_pk_task3.Models;

namespace Ab_pk_task3.StudentsOperations.CreateStudent
{
    public class CreateStudentCommand
    {
        public CreateStudentModel Model { get; set; }
        private readonly PatikaDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateStudentCommand(PatikaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var student = _dbContext.Students.Where(x => x.Name == Model.Name && x.Surname == Model.Surname).SingleOrDefault();

            if (student is not null)
                throw new InvalidOperationException("Ögrenci Zaten Mevcut");

            student = _mapper.Map   <Student>(Model); 
            // Auto mapper halletti
            //new Student();
            //student.Name = Model.Name;
            //student.Surname = Model.Surname;
            //student.BookGenreId = Model.BookGenreId;
            //student.ClassId = Model.ClassId;
            //student.TestDate = Model.TestDate;

            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();

        }
    }
    public class CreateStudentModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ClassId { get; set; }
        public int BookGenreId { get; set; }
        public DateTime TestDate { get; set; }
    }
}
