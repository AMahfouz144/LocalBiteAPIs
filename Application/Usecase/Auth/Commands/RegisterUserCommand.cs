
using Application.Usecase.Auth.DTOs;
using MediatR;
namespace Application.Usecase.Auth.Commands
{
    public record RegisterUserCommand(RegisterUserDto UserDto) : IRequest<string>;

}
