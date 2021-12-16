using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CustomerAPI.Helpers;
using CustomerApplication.Commands.UserCommands;
using CustomerDomain.Domain;
using CustomerDomain.Entity;
using CustomerInfra.Repositories;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CustomerApplication.Handlers.UsersCommands
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, AuthenticateResponse>
    {
        private readonly IRepository<User> _userRepository;
        private readonly AppSettings _appSettings;
        
        public CreateUserHandler(IRepository<User> userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }
        
        
        public Task<AuthenticateResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetAll().Result.FirstOrDefault(x => x.Username == request.Username && x.Password == request.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);
            
            var result = new AuthenticateResponse(user, token);

            return Task.FromResult(result);
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}