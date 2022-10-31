using FluentValidation;

namespace Application.Commands.UpdateRoom;

public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
{
    public UpdateRoomCommandValidator()
    {
        RuleFor(createRoomCommand => createRoomCommand.Address)
            .MaximumLength(200);
        RuleFor(createRoomCommand => createRoomCommand.Price)
            .GreaterThan(1);
    }
}
