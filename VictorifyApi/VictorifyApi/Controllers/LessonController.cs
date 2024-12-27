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
        public async Task<ActionResult<List<Lesson>>> AddLesson([FromBody] CreateLessonDto createLessonDto)
        {
            var teacher = await _context.Teachers.FindAsync(createLessonDto.TeacherId);
            var student = await _context.Students.FindAsync(createLessonDto.StudentId);

            if (teacher == null || student == null)
            {
                return BadRequest("Teacher or Student not found.");
            }

            var lesson = new Lesson
            {
                Date = createLessonDto.Date,
                Current = createLessonDto.Current,
                TeacherId = createLessonDto.TeacherId,
                StudentId = createLessonDto.StudentId
            };

            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();

            return Ok(await _context.Lessons.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<Lesson>>> GetAllLessons()
        {
            return Ok(await _context.Lessons
                .Include(l => l.Teacher)
                .Include(l => l.Student)
                .ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Lesson>> GetLesson(int id)
        {
            var lesson = await _context.Lessons
                .Include(l => l.Teacher)
                .Include(l => l.Student)
                .FirstOrDefaultAsync(l => l.Id == id);

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

        [HttpGet("search")]
        public async Task<ActionResult<List<Lesson>>> SearchLessons([FromQuery] int? studentId, [FromQuery] int? teacherId)
        {
            var query = _context.Lessons.AsQueryable();

            if (studentId.HasValue)
            {
                query = query.Where(l => l.StudentId == studentId.Value);
            }

            if (teacherId.HasValue)
            {
                query = query.Where(l => l.TeacherId == teacherId.Value); 
            }

            return Ok(await query
                .Include(l => l.Teacher)
                .Include(l => l.Student)
                .ToListAsync());
        }
    }
}
