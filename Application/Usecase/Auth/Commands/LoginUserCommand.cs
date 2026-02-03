using Application.Common;
using Application.Usecase.Auth.DTOs;
using MediatR;

namespace Application.Usecase.Auth.Commands
{
    //public record LoginUserCommand(LoginUserDto UserDto) : IRequest<string>;
    public class LoginUserCommand:BaseModel,IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}