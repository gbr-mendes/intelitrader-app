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
        [Required]
        public DateTime CreationDate { get; private set; } = DateTime.UtcNow;


        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }
        [JsonConstructorAttribute]
        public User(string name, string surName, int age)
        {
            Name = name;
            SurName = surName;
            Age = age;
        }
        public User(string id, string name, string surName, int age)
        {
            Id = id;
            Name = name;
            SurName = surName;
            Age = age;
        }
    }
}