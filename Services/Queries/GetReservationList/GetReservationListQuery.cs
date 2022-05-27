using Contracts.DTO;
using MediatR;

namespace Application.Queries.GetReservations;

public record GetReservationListQuery : IRequest<List<ReservationDTO>>;
