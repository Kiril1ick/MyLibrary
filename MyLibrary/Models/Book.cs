using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Models
{
    [Table("Books", Schema = "HR")]
    public class Book
    {
        [Key]
        [Display(Name = "ID")]
        public int? BookId { get; set; }

        [Display(Name = "Title")]
        [Column(TypeName ="varchar(50)")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Cover")]
        [Column(TypeName = "varchar(250)")]
        public string? Cover { get; set; }

        [Display(Name ="Author")]
        [Column(TypeName ="varchar(60)")]
        public string Author { get; set; }

        public int GenreID { get; set; }
        [ForeignKey("GenreID")]
        public Genre? Genre { get; set; }
    }
}
