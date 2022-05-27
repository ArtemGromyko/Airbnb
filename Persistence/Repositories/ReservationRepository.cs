using Airbnb.DAL.Repositories;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
{
    public ReservationRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

    public async Task<Reservation> GetReservationByIdAsync(Guid id) =>
        await FindByCondition(r => r.Id.Equals(id)).SingleOrDefaultAsync();

    public async Task<List<Reservation>> GetReservationListAsync() =>
        await FindAll().ToListAsync();

    public async Task<List<Reservation>> GetReservationListForRoomAsync(Guid roomId) =>
        await FindByCondition(r => r.RoomId.Equals(roomId)).ToListAsync();

    public async Task<Reservation> GetReservationForRoomAsync(Guid roomId, Guid id) =>
        await FindByCondition(r => r.RoomId.Equals(roomId) && r.Id.Equals(id)).SingleOrDefaultAsync();

    public async Task CreateReservationAsync(Reservation reservation) =>
        await CreateAsync(reservation);

    public async Task UpdateReservationAsync(Reservation reservation) =>
        await UpdateAsync(reservation);

    public async Task DeleteReservationAsync(Reservation reservation) =>
        await DeleteAsync(reservation);
}
