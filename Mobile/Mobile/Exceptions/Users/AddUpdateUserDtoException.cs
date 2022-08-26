using System;

namespace Mobile.Exceptions.Users
{
    public class AddUpdateUserDtoException: Exception
    {
        public AddUpdateUserDtoException(string message) : base(message) { }
    }
}
