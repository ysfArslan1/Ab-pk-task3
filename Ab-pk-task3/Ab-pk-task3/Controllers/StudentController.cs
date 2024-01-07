using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Ab_pk_task3.DBOperations;

using Ab_pk_task3.Models;
using Ab_pk_task3.BankAccountOperations.GetBA;
using Ab_pk_task3.StudentsOperations.CreateStudent;
using Ab_pk_task3.StudentsOperations.GetStudentDetail;
using Ab_pk_task3.Common;
using Ab_pk_task3.StudentsOperations.UpdateStudent;
using Ab_pk_task3.StudentsOperations.DeleteStudent;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using FluentValidation.Results;
using FluentValidation;

namespace Ab_pk_task3.Controllers
{
    // datagenerator.cs, bankdbcontext, bankaccount, program, strtup sınıfları degistirildi
    [ApiController]
    [Route("[controller]s")]
    public class StudentController : ControllerBase
    {
        private readonly PatikaDbContext _context;
        private readonly IMapper _mapper;

        public StudentController(PatikaDbContext bankDbContext, IMapper mapper)
        {
            _context = bankDbContext;
            _mapper = mapper;
        }

        // GET: get GetStudents
        [HttpGet]
        public IActionResult GetStudents()
        {
            GetStudentQuery query = new GetStudentQuery(_context, _mapper);
            var _list = query.Handle();
            return Ok(_list);
        }

        // GET: get Student from id
        [HttpGet("{id}")]
        public ActionResult<StudentDetailViewModel> GetStudentById([FromRoute] int id)
        {
            StudentDetailViewModel result;
            try
            {
                GetStudentDetailQuery query = new GetStudentDetailQuery(_context, _mapper);
                query.StudentID = id;
                GetStudentDetailQueryValidator validator = new GetStudentDetailQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

        // Post: create a Student
        [HttpPost]
        public IActionResult AddStudent([FromBody] CreateStudentModel newModel)
        {
            CreateStudentCommand command = new CreateStudentCommand(_context, _mapper);
            try
            {
                command.Model = newModel;

                CreateStudentCommandValidator _validator=new CreateStudentCommandValidator();
                _validator.ValidateAndThrow(newModel);
                command.Handle();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // PUT: update a Student
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] UpdateStudentModel updateStudent)
        {

            try
            {
                UpdateStudentCommand command = new UpdateStudentCommand(_context);
                command.StudentID = id;
                command.Model = updateStudent;
                UpdateStudentCommandValidator validator  = new UpdateStudentCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // DELETE: delete a Student
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                DeleteStudentCommand command = new DeleteStudentCommand(_context);
                command.StudentID = id;
                DeleteStudentCommandValidator _validator = new DeleteStudentCommandValidator();
                _validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

    }
}
