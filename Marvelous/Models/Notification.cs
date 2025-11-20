using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marvelous.Models
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        public string EntityName { get; set; } // e.g., "Villa" or "VillaNumber"
        public int EntityId { get; set; }      // e.g., Villa.Id

        public bool IsRead { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
