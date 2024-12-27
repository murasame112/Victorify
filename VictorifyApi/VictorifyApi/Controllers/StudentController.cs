using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VictorifyApi.Data;
using VictorifyApi.Models;

namespace VictorifyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public StudentsController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddStudent([FromBody] CreateStudentDto createStudentDto)
        {
            var student = new Student
            {
                Name = createStudentDto.Name,
                Surname = createStudentDto.Surname,
                Nickname = createStudentDto.Nickname,
                Email = createStudentDto.Email
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }


        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            return Ok(await _context.Students.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound("Student not found.");
            }
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound("Student not found.");
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateStudent(int id, [FromBody] UpdateStudentDto updatedStudent)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound("Student not found.");
            }

            if (updatedStudent.Name != null) student.Name = updatedStudent.Name;
            if (updatedStudent.Surname != null) student.Surname = updatedStudent.Surname;
            if (updatedStudent.Nickname != null) student.Nickname = updatedStudent.Nickname;
            if (updatedStudent.Email != null) student.Email = updatedStudent.Email;

            await _context.SaveChangesAsync();

            return Ok(student);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<Student>>> SearchStudents([FromQuery] string email)
        {
            var query = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(s => s.Email.Contains(email));
            }

            return Ok(await query.ToListAsync());
        }
    }
}
