namespace pubs.Infrastructure.Interfaces
{
    public interface ICustomlogger
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message);
    }
}
