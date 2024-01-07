
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ab_pk_task3.Common;
using Ab_pk_task3.DBOperations;
using Ab_pk_task3.Models;

namespace Ab_pk_task3.StudentsOperations.CreateStudent
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentModel>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x=>x.Surname).NotEmpty().MaximumLength(50);
            RuleFor(x => x.ClassId).GreaterThan(0).LessThan(4);
            RuleFor(x => x.BookGenreId).GreaterThan(0).LessThan(5);
        }

    }
}
