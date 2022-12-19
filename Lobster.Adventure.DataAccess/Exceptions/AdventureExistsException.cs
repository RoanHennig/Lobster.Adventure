namespace Lobster.Adventure.DataAccess.Exceptions;

public class AdventureExistsException : Exception
{
    public AdventureExistsException(string message, Exception exception) : base(message, exception)
    {

    }
}
