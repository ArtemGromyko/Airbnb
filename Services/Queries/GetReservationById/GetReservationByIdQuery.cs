using Contracts.DTO;
using MediatR;

namespace Application.Queries.GetReservationById;

public record GetReservationByIdQuery(Guid Id) : IRequest<ReservationDTO>;
