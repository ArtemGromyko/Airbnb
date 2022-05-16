using Domain.Entities;

namespace Domain.Repositories;

public interface IRepositoryContext
{
    IQueryable<Room> Rooms { get; set; }
    Task<bool> SaveChangeAsync(CancellationToken cancellationToken);
}
