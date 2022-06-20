using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Models
{
    [Table("Genres", Schema = "HR")]
    public class Genre
    {
        [Key]
        [Display(Name = "ID")]
        public int Book_id { get; set; }

        [Required]
        [Display(Name = "Genre Name")]
        [Column(TypeName = "varchar(50)")]
        public string GenreName { get; set; } = string.Empty;

    }
}
