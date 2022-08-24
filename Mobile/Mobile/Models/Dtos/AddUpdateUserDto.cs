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

        public AddUpdateUserDto() { }
        public AddUpdateUserDto(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public AddUpdateUserDto(string name, string surName, int age)
        {
            Name = name;
            SurName = surName;
            Age = age;
        }
    }
}
