using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VictorifyApi.Data;
using VictorifyApi.Models;

namespace VictorifyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public TeachersController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<List<Teacher>>> AddTeacher([FromBody] CreateTeacherDto createTeacherDto)
        {
            var teacher = new Teacher
            {
                Name = createTeacherDto.Name,
                Surname = createTeacherDto.Surname,
                Nickname = createTeacherDto.Nickname,
                Email = createTeacherDto.Email,
                HourlyRate = createTeacherDto.HourlyRate
            };

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return Ok(await _context.Teachers.ToListAsync());
        }


        [HttpGet]
        public async Task<ActionResult<List<Teacher>>> GetAllTeachers()
        {
            return Ok(await _context.Teachers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return BadRequest("Teacher not found.");
            }
            return Ok(teacher);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound("Teacher not found.");
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateTeacher(int id, [FromBody] UpdateTeacherDto updatedTeacher)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound("Teacher not found.");
            }

            if (updatedTeacher.Name != null) teacher.Name = updatedTeacher.Name;
            if (updatedTeacher.Surname != null) teacher.Surname = updatedTeacher.Surname;
            if (updatedTeacher.Nickname != null) teacher.Nickname = updatedTeacher.Nickname;
            if (updatedTeacher.Email != null) teacher.Email = updatedTeacher.Email;
            if (updatedTeacher.HourlyRate.HasValue) teacher.HourlyRate = updatedTeacher.HourlyRate.Value;

            await _context.SaveChangesAsync();

            return Ok(teacher);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<Teacher>>> SearchTeachers([FromQuery] string email)
        {
            var query = _context.Teachers.AsQueryable();

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(t => t.Email.Contains(email));
            }

            return Ok(await query.ToListAsync());
        }
    }
}
