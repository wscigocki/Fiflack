using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiflack.LocalDb.Models
{
    [Table("Players")]
    public class PlayerDb
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Login { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}