namespace Diary.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;  
        public string Password { get; set; } = null!;
        public List<UserDiary> UserDiaries { get; set; } = new();
    }
}