using System.ComponentModel.DataAnnotations;

namespace UserRegistration.Dtos.User
{
    public class AddUpdateUserDto
    {
        private string Id { get; set; } = System.Guid.NewGuid().ToString();
        [Required]
        public string Name { get; set; }
        public string SurName { get; set; }
        [Required]
        public int Age { get; set; }

        public string GetId()
        {
            return Id;
        }
        public void SetId(string id)
        {
            Id = id;
        }
    }
}