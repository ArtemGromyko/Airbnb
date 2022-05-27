using Application.Commands.CreateReservation;
using Application.Commands.DeleteReservation;
using Application.Commands.UpdateReservation;
using Application.Queries.GetReservationById;
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
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservationListAsync()
        {
            var reservationDTOs = await _mediator.Send(new GetReservationListQuery());

            return reservationDTOs is null ? NoContent() : Ok(reservationDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationByIdAsync(Guid id)
        {
            var reservationDTO = await _mediator.Send(new GetReservationByIdQuery(id));

            return Ok(reservationDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservationAsync(
            [FromBody]CreateReservationCommand command)
        {
            var reservationId = await _mediator.Send(command);
            
            return CreatedAtAction(nameof(GetReservationByIdAsync), new { id = reservationId }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UdpateReservationAsync(Guid id,
            [FromBody]UpdateReservationCommand command)
        {
            if (command.RoomId != id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservationAsync(Guid id)
        {
            await _mediator.Send(new DeleteReservationCommand(id));

            return NoContent();
        }
    }
}
