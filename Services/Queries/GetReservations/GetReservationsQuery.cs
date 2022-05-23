using Contracts.DTO;
using MediatR;

namespace Application.Queries.GetReservations;

public record GetReservationsQuery : IRequest<List<ReservationDTO>>;
