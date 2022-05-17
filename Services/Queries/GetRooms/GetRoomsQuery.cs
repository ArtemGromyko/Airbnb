using MediatR;

namespace Application.Queries.GetRooms;

public record GetRoomsQuery : IRequest<List<RoomDTO>>;
