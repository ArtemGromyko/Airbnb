using MediatR;

namespace Application.Commands.UpdateRoom;

public record UpdateRoomCommand(Guid Id, string Address, bool HasInternet, decimal Price) : IRequest;
