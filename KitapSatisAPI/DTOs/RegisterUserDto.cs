namespace KitapSatisAPI.DTOs
{
    public class RegisterUserDto
    {
        public string NameSurname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
