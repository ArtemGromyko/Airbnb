namespace Application.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, Guid key)
        : base($"Entity \"{name}\" ({key}) not found.") { }

    public NotFoundException(string name, Guid primaryKey, Guid foreignKey)
        : base($"Entity \"{name}\" primary id: ({primaryKey}), foreign id: ({foreignKey})") { }
}
