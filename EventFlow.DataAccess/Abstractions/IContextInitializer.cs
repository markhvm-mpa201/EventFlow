namespace EventFlow.DataAccess.Abstractions;

public interface IContextInitializer
{
    Task InitDatabaseAsync();
}
