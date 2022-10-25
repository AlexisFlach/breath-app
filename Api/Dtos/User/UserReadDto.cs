namespace Api.Dtos.User
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int? CurrentLevelId { get; set; }
        public Level.LevelReadDto? CurrentLevel { get; set; }
    }
}