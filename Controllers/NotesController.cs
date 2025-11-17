using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApi.Data;
using NotesApi.Models;

namespace NotesApi.Controllers
{
    [ApiController]
    [Route("notes")]
    public class NotesController : ControllerBase
    {
        private readonly NotesDbContext _db;

        public NotesController(NotesDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Note input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var note = new Note
            {
                Title = input.Title,
                Content = input.Content,
                CreatedAt = DateTime.UtcNow
            };

            _db.Notes.Add(note);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = note.Id }, note);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _db.Notes.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var note = await _db.Notes.FindAsync(id);
            if (note == null)
                return NotFound(new { message = "Note not found." });

            return Ok(note);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var note = await _db.Notes.FindAsync(id);
            if (note == null)
                return NotFound(new { message = "Note not found." });

            _db.Notes.Remove(note);
            await _db.SaveChangesAsync();

            return Ok(new { message = "Note deleted successfully." });
        }
    }
}
