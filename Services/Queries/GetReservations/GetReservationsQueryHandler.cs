using AutoMapper;
using Contracts.DTO;
using Domain.Repositories;
using MediatR;

namespace Application.Queries.GetReservations;

internal class GetReservationsQueryHandler : IRequestHandler<GetReservationsQuery, List<ReservationDTO>>
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IMapper _mapper;

    public GetReservationsQueryHandler(IReservationRepository reservationRepository, IMapper mapper)
    {
        _reservationRepository = reservationRepository;
        _mapper = mapper;
    }

    public async Task<List<ReservationDTO>> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
    {
        var reservations = await _reservationRepository.GetReservationListAsync();

        return _mapper.Map<List<ReservationDTO>>(reservations);
    }
}
