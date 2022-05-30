using Application.Commands.CreateReservation;
using Application.Commands.DeleteReservation;
using Application.Commands.UpdateReservation;
using Application.Queries.GetReservationById;
using Application.Queries.GetReservationForRoom;
using Application.Queries.GetReservationListForRoom;
using Application.Queries.GetReservations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/rooms/{roomId}/reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
        }

        [HttpGet("~/api/reservations")]
        public async Task<IActionResult> GetReservationListAsync()
        {
            var reservationDTOs = await _mediator.Send(new GetReservationListQuery());

            return reservationDTOs is null ? NoContent() : Ok(reservationDTOs);
        }

        [HttpGet("~/api/reservations/{id}")]
        public async Task<IActionResult> GetReservationByIdAsync(Guid id)
        {
            var reservationDTO = await _mediator.Send(new GetReservationByIdQuery(id));

            return Ok(reservationDTO);
        }


        [HttpGet]
        public async Task<IActionResult> GetReservationListForRoomAsync(Guid roomId)
        {
            var reservationDTOs = await _mediator.Send(new GetReservationListForRoomQuery(roomId));

            return reservationDTOs is null ? NotFound() : Ok(reservationDTOs); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationForRooomAsync(Guid roomId, Guid id)
        {
            var reservationDTO = await _mediator.Send(new GetReservationForRoomQuery(roomId, id));

            return Ok(reservationDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservationAsync(Guid roomId,
            [FromBody]CreateReservationCommand command)
        {
            if(roomId != command.RoomId)
            {
                return BadRequest();
            }

            var reservationId = await _mediator.Send(command);
            
            return CreatedAtAction(nameof(GetReservationForRooomAsync),
                new { roomId = command.RoomId, id = reservationId }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UdpateReservationAsync(Guid roomId, Guid id,
            [FromBody]UpdateReservationCommand command)
        {
            if (command.RoomId != roomId)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservationAsync(Guid roomId, Guid id)
        {
            await _mediator.Send(new DeleteReservationCommand(id));

            return NoContent();
        }
    }
}
