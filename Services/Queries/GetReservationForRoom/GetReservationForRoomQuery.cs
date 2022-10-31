using Contracts.DTO;
using MediatR;

namespace Application.Queries.GetReservationForRoom;

public record GetReservationForRoomQuery(Guid RoomId, Guid Id) : IRequest<ReservationDTO>;