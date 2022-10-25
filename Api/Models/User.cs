using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public int? CurrentLevelId { get; set; }
        public Level? CurrentLevel { get; set; }
    }
}