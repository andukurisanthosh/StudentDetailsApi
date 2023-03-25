using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentDetailsApi.Models;
using StudentDetailsApi.Services.StudentService;

namespace StudentDetailsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            var result = await _studentService.GetAllStudents();
            if(result == null)
            {
                return NotFound("no students found");
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var result = await _studentService.GetStudent(id);
            if(result == null)
            {
                return NotFound("sorry tis student does`t exist.");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddStudent(Student student)
        {
            var result = await _studentService.AddStudent(student);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Student>>> UpdateStudent(int id, Student request)
        {
            var result =await _studentService.UpdateStudent(id, request);
            if (result == null)
            {
                return NotFound("student not found");
            }
            return Ok(result);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int id, Student request)
        {
            var result = await _studentService.DeleteStudent(id);
            if (result == null)
            {
                return NotFound("sorry tis student does`t exist.");
            }
            return Ok(result);
        }
    }
}
