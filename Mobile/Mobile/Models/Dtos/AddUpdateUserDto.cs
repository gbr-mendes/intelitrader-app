using Mobile.Exceptions.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Models.Dtos
{
    public class AddUpdateUserDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("surName")]
        public string SurName { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        private void ValidateInstance(string name, int age)
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new AddUpdateUserDtoException("The field name is required");
            }
            if (age <= 0)
            {
                throw new AddUpdateUserDtoException("The field age must be greter than zero");
            }
        }
        public AddUpdateUserDto(string name, int age)
        {
            Name = name;
            Age = age;

            ValidateInstance(Name, Age);
        }

        public AddUpdateUserDto(string name, string surName, int age)
        {
            Name = name;
            SurName = surName;
            Age = age;

            ValidateInstance(Name, Age);
        }
    }
}
