using Application.Common.Exceptions;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Commands.UpdateReservation;

public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
{
    private readonly IMapper _mapper;
    private readonly IRoomRepository _roomRepository;
    private readonly IReservationRepository _reservationRepository;

    public UpdateReservationCommandHandler(IMapper mapper, IRoomRepository roomRepository,
        IReservationRepository reservationRepository)
    {
        _mapper = mapper;
        _roomRepository = roomRepository;
        _reservationRepository = reservationRepository;
    }

    public async Task<Unit> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetRoomByIdAsync(request.RoomId);
        if (room == null)
        {
            throw new NotFoundException(nameof(room), request.RoomId);
        }

        var reservation = await _reservationRepository.GetReservationForRoomAsync(
            request.RoomId, request.Id);
        if (reservation == null)
        {
            throw new NotFoundException(nameof(reservation), request.Id, request.RoomId);
        }

        reservation = _mapper.Map<Reservation>(request);
        await _reservationRepository.UpdateReservationAsync(reservation);

        return Unit.Value;
    }
}
