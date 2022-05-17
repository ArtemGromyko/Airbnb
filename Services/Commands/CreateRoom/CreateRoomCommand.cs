using MediatR;

namespace Application.Commands.CreateRoom;

public record CreateRoomCommand(string Address, bool HasInternet, decimal Price) : IRequest<Guid>;
