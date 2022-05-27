using Contracts.DTO;
using MediatR;

namespace Application.Queries.GetReservationForRoom;

public record GetReservationForRoomQuery(Guid roomId, Guid id) : IRequest<ReservationDTO>;