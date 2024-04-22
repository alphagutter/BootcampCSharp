namespace Core.Exceptions;

/// <summary>
/// Throws the exception when the transfer does not fullfill the requirements
/// </summary>
public class TransferErrorException : Exception
{

    //throws a message exception when the name exists in the entityname provided
    public TransferErrorException(string Message = "The Transfer must not be completed")
        : base(Message)
    {

    }
}