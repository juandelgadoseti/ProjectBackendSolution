namespace APIProjectBackend.Exceptions
{
    public class UpdateConflictException : Exception
    {
        public UpdateConflictException(string message) : base(message) { }
    }
}
