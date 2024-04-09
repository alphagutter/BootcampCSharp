
using System.Security.Cryptography.X509Certificates;

namespace Core.Exceptions;

/// <summary>
/// Exception class focused on return cases when it does not found data
/// </summary>
public class NotFoundException : Exception
{
    //throws a generic message when you not provide and specific message
    public NotFoundException(string message = "The requested source was not found") : base(message)
    {

    }

}