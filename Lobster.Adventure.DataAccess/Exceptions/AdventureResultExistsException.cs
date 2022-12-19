namespace Lobster.Adventure.DataAccess.Exceptions;

public class AdventureResultExistsException : Exception
{
    public AdventureResultExistsException(string message, Exception exception) : base(message, exception)
    {

    }
}