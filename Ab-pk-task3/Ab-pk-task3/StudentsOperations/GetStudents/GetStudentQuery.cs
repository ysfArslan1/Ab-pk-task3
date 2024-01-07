using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ab_pk_task3.Common;
using Ab_pk_task3.DBOperations;
using Ab_pk_task3.Models;

namespace Ab_pk_task3.BankAccountOperations.GetBA;
public class GetStudentQuery
{
    private readonly PatikaDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetStudentQuery(PatikaDbContext dbContext,IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public List<StudentViewModel> Handle()
    {
        var _list = _dbContext.Students.OrderBy(x => x.StudentId).ToList();
        List<StudentViewModel> result = _mapper.Map<List<StudentViewModel>>(_list) ;
            //new List<StudentViewModel>();
        //foreach (var item in _list)
        //{
        //    result.Add(new StudentViewModel()
        //    {
        //        Name = item.Name,
        //        Surname = item.Surname,
        //        Class = ((ClassEnum)item.ClassId).ToString(),
        //        BookGenre = ((BookGenreEnum)item.BookGenreId).ToString(),
        //        TestDate = item.TestDate.Date.ToString("dd/MM/yyyy"),
        //    });
        //}


        return result;
    }
}

public class StudentViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Class { get; set; }
    public string BookGenre { get; set; }
    public string TestDate { get; set; }
}

