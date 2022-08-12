using System.ComponentModel.DataAnnotations;


namespace UserRegistration.Models
{
    public class User
    {
        public string Id { get; set; } = System.Guid.NewGuid().ToString();
        [Required]
        public string Name { get; set; }
        public string SurName { get; set; }
        [Required]
        public int Age { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}