namespace KitapSatisAPI.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Message { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
