namespace Api.Dtos.Level
{
    public class LevelReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Inhale { get; set; }
        public int Exhale { get; set; }
        public int Duration { get; set; }
    }
}