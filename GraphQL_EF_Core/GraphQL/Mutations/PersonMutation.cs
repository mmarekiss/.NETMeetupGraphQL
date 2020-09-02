using GraphQL_EF_Core.Mediatr.Requests;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.GraphQL.Mutations
{
    public class PersonMutation
    {
        [Authorize]
        public Task<DTO.Person> Add([Service] IMediator mediator, AddPersonRequest person)
            => mediator.Send(person);
    }
}
