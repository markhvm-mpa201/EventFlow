using EventFlow.Business.Abstraction;

namespace EventFlow.Business.Exceptions;

public class RegisterFailException(string message = "Registration failed") : Exception(message), IBaseException
{
    public int StatusCode { get; set; } = 400;
}