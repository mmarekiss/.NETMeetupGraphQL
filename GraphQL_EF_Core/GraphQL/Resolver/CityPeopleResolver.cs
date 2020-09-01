using GraphQL_EF_Core.DTO;
using GraphQL_EF_Core.Mediatr.Requests;
using HotChocolate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.GraphQL.Resolver
{
    public class CityPeopleResolver
    {
        public Task<IQueryable<Person>> GetPeople([Parent] City city, [Service] IMediator mediator)
            => mediator.Send(new PeopleRequest() { City = city.Id });
    }
}
