using AutoMapper;
using Domain.Entities;
using Services.Features.Commands.Commands;

namespace Services.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMapsForRooms();
    }

    private void CreateMapsForRooms()
    {
        CreateMap<Room, RoomDTO>().ReverseMap();
        CreateMap<CreateRoomCommand, Room>();
    }
}
