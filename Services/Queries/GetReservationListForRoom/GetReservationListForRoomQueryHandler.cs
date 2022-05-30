using Application.Common.Exceptions;
using AutoMapper;
using Contracts.DTO;
using Domain.Repositories;
using MediatR;

namespace Application.Queries.GetReservationListForRoom;

public class GetReservationListForRoomQueryHandler
    : IRequestHandler<GetReservationListForRoomQuery, List<ReservationDTO>>
{
    private readonly IMapper _mapper;
    private readonly IRoomRepository _roomRepository;
    private readonly IReservationRepository _reservationRepository;

    public GetReservationListForRoomQueryHandler(IMapper mapper,
        IRoomRepository roomRepository, IReservationRepository reservationRepository)
    {
        _mapper = mapper;
        _roomRepository = roomRepository;
        _reservationRepository = reservationRepository;
    }

    public async Task<List<ReservationDTO>> Handle(GetReservationListForRoomQuery request,
        CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetRoomByIdAsync(request.RoomId);
        if (room == null)
        {
            throw new NotFoundException(nameof(room), request.RoomId);
        }

        var reservations = await _reservationRepository.GetReservationListForRoomAsync(request.RoomId);

        return _mapper.Map<List<ReservationDTO>>(reservations);
    }
}
