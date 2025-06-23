using System.ComponentModel.DataAnnotations;

namespace KitapSatisAPI.DTOs
{
    public class CreateBookDto
    {
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime PublishedDate { get; set; }

        [Required(ErrorMessage = "Kategori seçilmelidir.")]
        public int CategoryId { get; set; }
    }
}
