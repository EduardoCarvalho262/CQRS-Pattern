using System.ComponentModel.DataAnnotations;
using MediatR;

namespace CustomerDomain.Domain
{
    public class AuthenticateRequest : IRequest<AuthenticateResponse>
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}