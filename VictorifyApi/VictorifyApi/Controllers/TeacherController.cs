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

        // AddTeacher: Dodaje nowego nauczyciela.
        [HttpPost]
        public async Task<ActionResult<List<Teacher>>> AddTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return Ok(await _context.Teachers.ToListAsync());
        }

        // GetAllTeachers: Zwraca listę wszystkich nauczycieli.
        [HttpGet]
        public async Task<ActionResult<List<Teacher>>> GetAllTeachers()
        {
            return Ok(await _context.Teachers.ToListAsync());
        }

        // GetTeacher: Zwraca pojedynczego nauczyciela na podstawie ID.
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

        // DeleteTeacher: Usuwa nauczyciela na podstawie ID.
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

        // UpdateTeacher: Aktualizuje dane nauczyciela.
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

        // ReplaceTeacher: Zastępuje dane nauczyciela nowymi.
        [HttpPut("{id}")]
        public async Task<ActionResult> ReplaceTeacher(int id, [FromBody] Teacher newTeacher)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound("Teacher not found.");
            }

            teacher.Name = newTeacher.Name;
            teacher.Surname = newTeacher.Surname;
            teacher.Nickname = newTeacher.Nickname;
            teacher.Email = newTeacher.Email;
            teacher.HourlyRate = newTeacher.HourlyRate;

            await _context.SaveChangesAsync();

            return Ok(teacher);
        }

        // SearchTeachers: Przeszukuje nauczycieli na podstawie emaila.
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
