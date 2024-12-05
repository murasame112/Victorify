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

        //[HttpGet]
        //public IActionResult GetAllTeachers()
        //{
        //    var teachers = new List<string> { "John Doe", "Jane Smith" };
        //    return Ok(teachers);
        //}

        [HttpPost]
        public async Task<ActionResult<List<Teacher>>> AddTeacher(Teacher teacher)
        {
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

    }
}
