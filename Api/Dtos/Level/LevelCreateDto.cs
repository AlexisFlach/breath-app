namespace Api.Dtos.Level
{
    public class LevelCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Inhale { get; set; }
        public int Exhale { get; set; }
        public int Duration { get; set; }
    }
}