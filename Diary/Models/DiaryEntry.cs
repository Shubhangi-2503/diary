using System.ComponentModel.DataAnnotations;

namespace Diary.Models
{
    public class DiaryEntry
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public bool Disabled { get; set; }
        [Required] [MaxLength(100)]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
    }
}
