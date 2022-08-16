using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserRegistration.Models
{
    public class User
    {
        [Required]
        public string Id { get; private set; } = System.Guid.NewGuid().ToString();
        [Required]
        public string Name { get; set; }
        public string? SurName { get; set; }
        [Required]
        public int Age { get; set; }
        // [Required]
        public DateTime CreationDate { get; private set; } = DateTime.UtcNow;
    }
}