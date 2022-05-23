using Application.Commands.CreateRoom;
using Application.Commands.UpdateRoom;
using AutoMapper;
using Contracts.DTO;
using Domain.Entities;

namespace Services.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMapsForRooms();
        CreateMapsForReservations();
    }

    private void CreateMapsForRooms()
    {
        CreateMap<Room, RoomDTO>().ReverseMap();
        CreateMap<CreateRoomCommand, Room>();
        CreateMap<UpdateRoomCommand, Room>();
    }

    private void CreateMapsForReservations()
    {
        CreateMap<Reservation, ReservationDTO>().ReverseMap();
    }
}
