using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Ab_pk_task3.DBOperations;

namespace Ab_pk_task3.StudentsOperations.DeleteStudent
{
    public class DeleteStudentCommandValidator:AbstractValidator<DeleteStudentCommand>
    {
        public DeleteStudentCommandValidator()
        {
            RuleFor(x=>x.StudentID).NotEmpty().GreaterThan(0);
        }
    }
}

