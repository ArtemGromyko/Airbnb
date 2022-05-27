namespace Application.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, Guid key)
        : base($"Entity \"{name}\" ({key}) not found.") { }
}
