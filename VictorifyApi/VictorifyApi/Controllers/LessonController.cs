using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VictorifyApi.Data;
using VictorifyApi.Models;
using System.Linq;

namespace VictorifyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public LessonsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // AddLesson: Dodaje nową lekcję, przypisując nauczyciela i ucznia.
        [HttpPost]
        public async Task<ActionResult<List<Lesson>>> AddLesson(Lesson lesson)
        {
            var teacher = await _context.Teachers.FindAsync(lesson.TeacherId);
            var student = await _context.Students.FindAsync(lesson.StudentId);

            if (teacher == null || student == null)
            {
                return BadRequest("Teacher or Student not found.");
            }

            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();

            return Ok(await _context.Lessons.ToListAsync());
        }

        // GetAllLessons: Zwraca listę wszystkich lekcji.
        [HttpGet]
        public async Task<ActionResult<List<Lesson>>> GetAllLessons()
        {
            return Ok(await _context.Lessons
                .Include(l => l.Teacher) // Include tylko nauczyciela
                .Include(l => l.Student) // Include tylko ucznia
                .ToListAsync());
        }

        // GetLesson: Zwraca pojedynczą lekcję na podstawie ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<Lesson>> GetLesson(int id)
        {
            var lesson = await _context.Lessons
                .Include(l => l.Teacher) // Include tylko nauczyciela
                .Include(l => l.Student) // Include tylko ucznia
                .FirstOrDefaultAsync(l => l.Id == id);

            if (lesson == null)
            {
                return NotFound("Lesson not found.");
            }

            return Ok(lesson);
        }

        // DeleteLesson: Usuwa lekcję na podstawie ID.
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLesson(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound("Lesson not found.");
            }

            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // UpdateLesson: Aktualizuje dane lekcji.
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateLesson(int id, [FromBody] UpdateLessonDto updatedLesson)
        {
            var lesson = await _context.Lessons
                .Include(l => l.Teacher)
                .Include(l => l.Student)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (lesson == null)
            {
                return NotFound("Lesson not found.");
            }

            if (updatedLesson.Date.HasValue) lesson.Date = updatedLesson.Date.Value;
            if (updatedLesson.Current.HasValue) lesson.Current = updatedLesson.Current.Value;

            await _context.SaveChangesAsync();

            return Ok(lesson);
        }

        // ReplaceLesson: Zastępuje dane lekcji nowymi.
        [HttpPut("{id}")]
        public async Task<ActionResult> ReplaceLesson(int id, [FromBody] Lesson newLesson)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound("Lesson not found.");
            }

            lesson.Date = newLesson.Date;
            lesson.Current = newLesson.Current;
            lesson.TeacherId = newLesson.TeacherId; // Tylko ID nauczyciela
            lesson.StudentId = newLesson.StudentId; // Tylko ID ucznia

            await _context.SaveChangesAsync();

            return Ok(lesson);
        }

        // SearchLessons: Przeszukuje lekcje na podstawie ID ucznia lub nauczyciela.
        [HttpGet("search")]
        public async Task<ActionResult<List<Lesson>>> SearchLessons([FromQuery] int? studentId, [FromQuery] int? teacherId)
        {
            var query = _context.Lessons.AsQueryable();

            if (studentId.HasValue)
            {
                query = query.Where(l => l.StudentId == studentId.Value); // Wyszukiwanie po ID ucznia
            }

            if (teacherId.HasValue)
            {
                query = query.Where(l => l.TeacherId == teacherId.Value); // Wyszukiwanie po ID nauczyciela
            }

            return Ok(await query
                .Include(l => l.Teacher) // Include tylko nauczyciela
                .Include(l => l.Student) // Include tylko ucznia
                .ToListAsync());
        }
    }
}
