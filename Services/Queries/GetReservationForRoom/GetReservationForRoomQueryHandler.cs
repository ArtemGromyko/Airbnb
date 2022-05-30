using Application.Common.Exceptions;
using AutoMapper;
using Contracts.DTO;
using Domain.Repositories;
using MediatR;

namespace Application.Queries.GetReservationForRoom;

public class GetReservationForRoomQueryHandler : IRequestHandler<GetReservationForRoomQuery, ReservationDTO>
{
    private readonly IMapper _mapper;
    private readonly IRoomRepository _roomRepository;
    private readonly IReservationRepository _reservaitonRepository;

    public GetReservationForRoomQueryHandler(IMapper mapper, IRoomRepository roomRepository,
        IReservationRepository reservaitonRepository)
    {
        _mapper = mapper;
        _roomRepository = roomRepository;
        _reservaitonRepository = reservaitonRepository;
    }

    public async Task<ReservationDTO> Handle(GetReservationForRoomQuery request,
        CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetRoomByIdAsync(request.RoomId);
        if (room == null)
        {
            throw new NotFoundException(nameof(room), request.RoomId);
        }

        var reservation = await _reservaitonRepository.GetReservationForRoomAsync(request.RoomId, request.Id);
        if (reservation == null)
        {
            throw new NotFoundException(nameof(reservation), request.Id);
        }

        return _mapper.Map<ReservationDTO>(reservation);
    }
}
