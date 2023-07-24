namespace LibraryManagementSystem.Infrastructure.ExceptionHandler
{
    public class AuthenticationErrorException : Exception
    {
        public AuthenticationErrorException(string message) : base(message)
        {

        }
    }
}
