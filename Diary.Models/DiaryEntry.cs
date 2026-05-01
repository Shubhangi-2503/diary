using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diary.Models
{
    public class DiaryEntry
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 1)]
        public bool Enabled { get; set; }
        [Column(Order = 2)]
        //[Required(ErrorMessage = "Please enter Date!")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [Column(Order = 3)] 
        [Required]
        public int CreatedbyID { get; set; }
        [Column(Order = 4)]
        public DateTime? UpdatedOn { get; set; }
        [Column(Order = 5)]
        public int? UpdatedByID { get; set; }
        [Column(Order = 6)]
        public int? DisabledByID { get; set; } 
        [Column(Order = 7)]
        public DateTime? DisabledOn { get; set; }
        [Column(Order = 8)]
        [Required]
        public string Title { get; set; } = string.Empty;
        [Column(Order = 9)]
        [Required]
        public string Content { get; set; } = string.Empty;
    }
}
