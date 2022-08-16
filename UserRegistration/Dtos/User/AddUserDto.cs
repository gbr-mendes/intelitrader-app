using System.ComponentModel.DataAnnotations;

namespace UserRegistration.Dtos.User
{
    public class AddUserDto
    {
        [Required]
        public string Name { get; set; }
        public string? SurName { get; set; }
        [Required]
        public int Age { get; set; }
    }
}