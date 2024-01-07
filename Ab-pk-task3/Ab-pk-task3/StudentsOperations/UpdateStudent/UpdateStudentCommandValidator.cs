using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Ab_pk_task3.DBOperations;
using Ab_pk_task3.Models;

namespace Ab_pk_task3.StudentsOperations.UpdateStudent
{
    // UpdateStudentCommand sınıfın için oluşturulan validation sınıfı.
    public class UpdateStudentCommandValidator:AbstractValidator<UpdateStudentCommand>
    {
        
        public UpdateStudentCommandValidator()
        {
            RuleFor(x=>x.StudentID).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Model.Surname).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Model.ClassId).GreaterThan(0).LessThan(4);
            RuleFor(x => x.Model.BookGenreId).GreaterThan(0).LessThan(5);
        }
    }
    
}
