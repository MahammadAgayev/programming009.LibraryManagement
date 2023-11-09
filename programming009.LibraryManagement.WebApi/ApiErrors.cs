namespace programming009.LibraryManagement.WebApi
{
    public class ApiException : Exception
    {
        public ApiException(string? message) : base(message)
        {
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string? message) : base(message)
        {
        }
    }
}
