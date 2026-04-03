namespace BloggerAPI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public required int UserId { get; set; }
        public User? User { get; set; }
    }
}
