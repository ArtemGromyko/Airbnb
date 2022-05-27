using Application.Common.Exceptions;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Commands.CreateReservation;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IReservationRepository _reservationRepository;
    private readonly IRoomRepository _roomRepository;

    public CreateReservationCommandHandler(IMapper mapper, IReservationRepository reservationRepository,
        IRoomRepository roomRepository)
    {
        _mapper = mapper;
        _reservationRepository = reservationRepository;
        _roomRepository = roomRepository;
    }

    public async Task<Guid> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetRoomByIdAsync(request.RoomId);
        if (room == null)
        {
            throw new NotFoundException(nameof(room).ToLower(), request.RoomId);
        }

        var reservation = _mapper.Map<Reservation>(request);
        await _reservationRepository.CreateReservationAsync(reservation);

        return reservation.Id;
    }
}
