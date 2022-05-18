using FluentValidation;

namespace Application.Commands.CreateRoom;

public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
{
    public CreateRoomCommandValidator()
    {
        RuleFor(createRoomCommand => createRoomCommand.Address).NotEmpty().MaximumLength(200);
        RuleFor(createRoomCommand => createRoomCommand.Price).NotEmpty().GreaterThan(1);
    }
}
