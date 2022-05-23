using Application.Queries.GetReservations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservationListAsync()
        {
            var reservationDTOs = await _mediator.Send(new GetReservationsQuery());

            return reservationDTOs is null ? NoContent() : Ok(reservationDTOs);
        }
    }
}
