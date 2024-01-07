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
        //tüm ögrenci verileri databaseden alınır.
        var _list = _dbContext.Students.OrderBy(x => x.StudentId).ToList();
        // mapping ile Student sınıfından StudentViewModel verisi oluşturulur
        List<StudentViewModel> result = _mapper.Map<List<StudentViewModel>>(_list) ;
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

