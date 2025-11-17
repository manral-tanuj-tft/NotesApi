using System.ComponentModel.DataAnnotations;

namespace NotesApi.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = null!;

        public string? Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
