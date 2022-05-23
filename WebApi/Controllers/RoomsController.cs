using Application.Commands.CreateRoom;
using Application.Commands.DeleteRoom;
using Application.Commands.UpdateRoom;
using Application.Queries.GetRoomById;
using Application.Queries.GetRooms;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/rooms")]
[ApiController]
public class RoomsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public RoomsController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetRoomListAsync()
    {
        var roomDTOs = await _mediator.Send(new GetRoomsQuery());

        return roomDTOs is null ? NoContent() : Ok(roomDTOs);
    }

    [HttpGet("id", Name = "GetRoomByIdAsync")]
    public async Task<IActionResult> GetRoomByIdAsync(Guid id)
    {
        var roomDTO = await _mediator.Send(new GetRoomByIdQuery(id));

        return Ok(roomDTO);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoomAsync([FromBody]CreateRoomCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtRoute(nameof(GetRoomByIdAsync), new { id = id }, null);
    }

    [HttpPut("id")]
    public async Task<IActionResult> UpdateRoomAsync(Guid id, [FromBody]UpdateRoomCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("id")]
    public async Task<IActionResult> DeleteRoomAsync(Guid id)
    {
        await _mediator.Send(new DeleteRoomCommand(id));

        return NoContent();
    }
}
