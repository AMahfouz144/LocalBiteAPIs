using Application.Persistence.IRepositories;
using Application.Usecase.Auth.Commands;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Users;
using MediatR;

namespace Application.Usecase.Auth.Handler
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public RegisterUserHandler(IUserRepository userRepository,ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var dto = request.UserDto;

            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUser != null)
                throw new Exception("User already exists");

            var salt = Guid.NewGuid().ToString("N");


            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password + salt);

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                Salt = salt,
                HashPassword = hashedPassword,
                UserRole = UserRole.Customer,
                IsActive = true,
                CreatedBy = UserRole.Customer.ToString(),
                UpdatedBy = UserRole.Customer.ToString()
            };

            await _userRepository.AddAsync(user);
            var token = _tokenService.GenerateAccessToken(user);
            return token;
        }
    }
}