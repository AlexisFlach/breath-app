using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Level
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Inhale { get; set; }
        public int Exhale { get; set; }
        public int Duration { get; set; }
    }
}