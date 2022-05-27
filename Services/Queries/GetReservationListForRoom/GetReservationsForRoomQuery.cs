using Contracts.DTO;
using MediatR;

namespace Application.Queries.GetReservationListForRoom;

public record GetReservationListForRoomQuery(Guid roomId) : IRequest<List<ReservationDTO>>;
