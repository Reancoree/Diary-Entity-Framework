using System.ComponentModel.DataAnnotations.Schema;

namespace Diary.Entities
{
    public class UserDiary
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime DateTime { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
    }
}
