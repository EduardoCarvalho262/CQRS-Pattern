using CustomerDomain.Entity;
using MediatR;

namespace CustomerApplication.Queries.UserQueries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}