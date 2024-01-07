using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Ab_pk_task3.BankAccountOperations.GetBA;
using Ab_pk_task3.Common;
using Ab_pk_task3.DBOperations;

namespace Ab_pk_task3.StudentsOperations.GetStudentDetail
{
    public class GetStudentDetailQueryValidator : AbstractValidator<GetStudentDetailQuery>
    {

        public GetStudentDetailQueryValidator()
        {
            RuleFor(x=>x.StudentID).NotEmpty().GreaterThan(0);
        }
        
    }

}
