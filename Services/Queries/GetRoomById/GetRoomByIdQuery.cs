using MediatR;

namespace Application.Queries.GetRoomById;

public record GetRoomByIdQuery(Guid Id) : IRequest<RoomDTO>;
