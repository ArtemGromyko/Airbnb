using MediatR;

namespace Application.Queries.GetRooms;

public record GetRoomListQuery : IRequest<List<RoomDTO>>;
