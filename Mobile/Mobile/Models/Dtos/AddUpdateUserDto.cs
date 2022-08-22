using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Models.Dtos
{
    internal class AddUpdateUserDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
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
