using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Models.Dtos
{
    public class GetUserDto
    {
        public string Id { get; private set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public DateTime CreationDate { get; private set; }
    }
}
