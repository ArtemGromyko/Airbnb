using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Airbnb.DAL.Repositories;

public class RoomRepository : RepositoryBase<Room>, IRoomRepository
{
    public RoomRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

    public async Task<Room> GetRoomByIdAsync(Guid id) =>
        await FindByCondition(r => r.Id.Equals(id)).SingleOrDefaultAsync();
    public async Task<List<Room>> GetRoomListAsync() =>
        await FindAll().ToListAsync();

    public async Task CreateRoomAsync(Room room) =>
        await CreateAsync(room);

    public async Task UpdateRoomAsync(Room room) =>
        await UpdateAsync(room);

    public async Task DeleteRoomAsync(Room room) =>
        await DeleteAsync(room);
}
