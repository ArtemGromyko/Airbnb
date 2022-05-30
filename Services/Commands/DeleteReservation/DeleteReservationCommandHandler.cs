using Application.Common.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Commands.DeleteReservation;

public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
{
    private readonly IReservationRepository _reservatioRepository;
    private readonly IRoomRepository _roomRepository;

    public DeleteReservationCommandHandler(IReservationRepository reservatioRepository, IRoomRepository roomRepository)
    {
        _reservatioRepository = reservatioRepository;
        _roomRepository = roomRepository;
    }

    public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetRoomByIdAsync(request.RoomId);
        if (room == null)
        {
            throw new NotFoundException(nameof(room), request.RoomId);
        }

        var reservation = await _reservatioRepository.GetReservationForRoomAsync(request.RoomId, request.Id);
        if (reservation == null)
        {
            throw new NotFoundException(nameof(reservation), request.Id, request.RoomId);
        }

        await _reservatioRepository.DeleteReservationAsync(reservation);

        return Unit.Value;
    }
}
