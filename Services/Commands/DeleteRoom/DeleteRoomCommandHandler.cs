using Domain.Repositories;
using MediatR;

namespace Application.Commands.DeleteRoom;

internal class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand>
{
    private readonly IRoomRepository _roomRepository;

    public DeleteRoomCommandHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetRoomByIdAsync(request.Id);

        await _roomRepository.DeleteRoomAsync(room);

        return Unit.Value;
    }
}
