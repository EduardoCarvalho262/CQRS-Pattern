using System.Collections.Generic;
using CustomerDomain.Entity;
using MediatR;

namespace CustomerApplication.Queries.UserQueries
{
    public class GetAllUsersQuery : IRequest<List<User>>{}
}