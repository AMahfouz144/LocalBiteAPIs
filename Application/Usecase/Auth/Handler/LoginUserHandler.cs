
using Application.Common;
using Application.Exceptions;
using Application.Persistence.IRepositories;
using Application.Usecase.Auth.Commands;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Usecase.Auth.Handler
{
    public class LoginUserHandler : BaseHandler<LoginUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly ILogger<LoginUserHandler> _logger;



        public LoginUserHandler(IUserRepository userRepository, ITokenService tokenService,ILogger<LoginUserHandler> logger)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _logger = logger;

        }

        protected override async Task<string> HandleValidated(LoginUserCommand request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.GetByEmailAsync(request.Email);
            _logger.LogError($"user :{user.Email} This is a password : {user.HashPassword}");

            if (user == null)
                throw new InvalidCredentialsException("Invalid email or password");
            var token = _tokenService.GenerateAccessToken(user);


            var isValid = BCrypt.Net.BCrypt.Verify(request.Password + user.Salt, user.HashPassword);
            if (!isValid)
                throw new InvalidCredentialsException("Invalid email or password");
            _logger.LogInformation($"user {user.Email} {user.HashPassword}");
            return token;
        }

    }
}