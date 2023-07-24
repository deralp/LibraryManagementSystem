namespace LibraryManagementSystem.Infrastructure.ExceptionHandler
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }

    }
}
