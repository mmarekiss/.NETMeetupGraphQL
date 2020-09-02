using GraphQL_EF_Core.DTO;
using GraphQL_EF_Core.Mediatr.Requests;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.GraphQL.Queries
{
    public class PersonQuery
    {
        private readonly IMediator mediator;

        public PersonQuery(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [UsePaging] //Add generic paging
        [UseFiltering] //Add generic filering
        [UseSorting] //Add generic sorting
        [UseSelection]
        public async Task<IQueryable<Person>> GetPersons()
        {
            return await mediator.Send(new PeopleRequest());
        }
    }
}
