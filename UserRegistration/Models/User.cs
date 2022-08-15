using System.ComponentModel.DataAnnotations;
namespace UserRegistration.Models
{
    public class User
    {
        [Required]
        public string Id { get; private set; } = System.Guid.NewGuid().ToString();
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? SurName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public DateTime CreationDate { get; private set; } = DateTime.UtcNow;

        public User() { }
        public User(string id, string name, string surName, int age)
        {
            Id = id;
            Name = name;
            SurName = surName;
            Age = age;
        }
    }
}