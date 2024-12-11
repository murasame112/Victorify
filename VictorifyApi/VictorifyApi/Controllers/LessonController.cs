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

        [HttpPost]
        public async Task<ActionResult<List<Lesson>>> AddLesson(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();

            return Ok(await _context.Lessons.Include(l => l.Students).Include(l => l.Teachers).ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<Lesson>>> GetAllLessons()
        {
            return Ok(await _context.Lessons.Include(l => l.Students).Include(l => l.Teachers).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lesson>> GetLesson(int id)
        {
            var lesson = await _context.Lessons.Include(l => l.Students).Include(l => l.Teachers).FirstOrDefaultAsync(l => l.Id == id);
            if (lesson == null)
            {
                return NotFound("Lesson not found.");
            }
            return Ok(lesson);
        }

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

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateLesson(int id, [FromBody] UpdateLessonDto updatedLesson)
        {
            var lesson = await _context.Lessons.Include(l => l.Students).Include(l => l.Teachers).FirstOrDefaultAsync(l => l.Id == id);
            if (lesson == null)
            {
                return NotFound("Lesson not found.");
            }

            if (updatedLesson.Date.HasValue) lesson.Date = updatedLesson.Date.Value;
            if (updatedLesson.Current.HasValue) lesson.Current = updatedLesson.Current.Value;

            await _context.SaveChangesAsync();

            return Ok(lesson);
        }

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
            lesson.Students = newLesson.Students;
            lesson.Teachers = newLesson.Teachers;

            await _context.SaveChangesAsync();

            return Ok(lesson);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<Lesson>>> SearchLessons([FromQuery] int? studentId, [FromQuery] int? teacherId)
        {
            var query = _context.Lessons.Include(l => l.Students).Include(l => l.Teachers).AsQueryable();

            if (studentId.HasValue)
            {
                query = query.Where(l => l.Students.Any(s => s.Id == studentId.Value));
            }

            if (teacherId.HasValue)
            {
                query = query.Where(l => l.Teachers.Any(t => t.Id == teacherId.Value));
            }

            return Ok(await query.ToListAsync());
        }


    }


}
