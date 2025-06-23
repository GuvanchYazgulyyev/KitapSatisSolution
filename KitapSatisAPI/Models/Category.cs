namespace KitapSatisAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // Bir kategoride birden fazla kitap olabilir
        public ICollection<Book>? Books { get; set; }
    }
}
