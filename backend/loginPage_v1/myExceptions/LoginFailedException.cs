using System;

namespace loginPage_v1.myExceptions
{
    public class LoginFailedException : Exception
    {
        public LoginFailedException() : base() { }
        public LoginFailedException(string message) : base(message) { }
    }
}